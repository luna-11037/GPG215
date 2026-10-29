
using System.Collections;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [Header("References")]
    //[SerializeField] private GameObject player;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform laserOrigin;
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private LayerMask playerLayer;

    [Header("Timing")]
    [SerializeField] private float chargeTime = 1f;
    [SerializeField] private float activeTime = 2f;
    [SerializeField] private float cooldownTime = 2f;

    [Header("Beam")]
    [SerializeField] private float beamLength = 20f;
    [SerializeField] private float turnSpeed = 90f;
    private Vector2 laserDirection;

    private float currentAngle;
    private bool isAttacking;

    private void Start()
    {
        laserLine.enabled = false;

        StartCoroutine(LaserLoop());
    }

    private IEnumerator LaserLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(chargeTime);

            isAttacking = true;
            laserLine.enabled = true;

            yield return new WaitForSeconds(activeTime);

            isAttacking = false;
            laserLine.enabled = false;

            yield return new WaitForSeconds(cooldownTime);
        }
    }

    private void Update()
    {
        if (!isAttacking || playerPosition == null ||
            laserOrigin == null || laserLine == null)
            return;

        FindPlayer();

        HandleLaser();
    }

    private void FindPlayer()
    {
        Vector2 followPlayer =
            (Vector2)playerPosition.position -
            (Vector2)laserOrigin.position;

        float targetAngle =
            Mathf.Atan2(followPlayer.y, followPlayer.x) * Mathf.Rad2Deg;

        currentAngle = Mathf.MoveTowardsAngle(
            currentAngle,
            targetAngle,
            turnSpeed * Time.deltaTime
        );

        laserDirection = new Vector2(
            Mathf.Cos(currentAngle * Mathf.Deg2Rad),
            Mathf.Sin(currentAngle * Mathf.Deg2Rad)
        );
    }

    private void HandleLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            laserOrigin.position,
            laserDirection,
            beamLength,
            playerLayer
        );

        Vector2 endPosition;

        if (hit.collider != null)
        {
            endPosition = hit.point;

            Debug.DrawLine(
                laserOrigin.position,
                hit.point
            );

            Debug.Log("Laser hit: " + hit.collider.name);

            DamagePlayer();
        }
        else
        {
            endPosition =
                (Vector2)laserOrigin.position +
                laserDirection * beamLength;
        }

        laserLine.SetPosition(0, laserOrigin.position);
        laserLine.SetPosition(1, endPosition);
    }

    public void DamagePlayer()
    {

    }
}
