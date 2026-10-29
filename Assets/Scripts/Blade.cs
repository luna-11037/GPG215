
using UnityEngine;
using UnityEngine.InputSystem;

public class Blade : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionReference pressAction;
    public InputActionReference positionAction;

    [Header("References")]
    public GameObject bladeTrailPrefab;
    [SerializeField] private BossHealth bossHealth;

    [Header("Variables")]
    public float minCuttingVelocity = 0.001f;
    public float bladeDamage = 25f;

    private bool isCutting = false;
    private Vector2 previousPosition;

    private GameObject currentBladeTrail;

    private Rigidbody2D rb;
    private Camera cam;
    private CircleCollider2D circleCollider;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        circleCollider.enabled = false;
    }

    void OnEnable()
    {
        pressAction.action.Enable();
        positionAction.action.Enable();
    }

    void OnDisable()
    {
        pressAction.action.Disable();
        positionAction.action.Disable();
    }

    void Update()
    {
        if (pressAction.action.WasPressedThisFrame())
        {
            StartCutting();
        }

        if (isCutting && pressAction.action.IsPressed())
        {
            UpdateCut();
        }

        if (pressAction.action.WasReleasedThisFrame())
        {
            StopCutting();
        }
    }

    void UpdateCut()
    {
        Vector2 screenPosition =
            positionAction.action.ReadValue<Vector2>();

        Vector2 newPosition = cam.ScreenToWorldPoint(screenPosition);

        rb.position = newPosition;

        float velocity =
            (newPosition - previousPosition).magnitude /
            Time.deltaTime;

        circleCollider.enabled = velocity > minCuttingVelocity;

        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;

        previousPosition = cam.ScreenToWorldPoint(
            positionAction.action.ReadValue<Vector2>());

        currentBladeTrail = Instantiate(
            bladeTrailPrefab,
            transform.position,
            Quaternion.identity,
            transform
        );

        isCutting = true;
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        if (!isCutting)
            return;

        isCutting = false;

        if (currentBladeTrail != null)
        {
            currentBladeTrail.transform.SetParent(null);
            Destroy(currentBladeTrail, 2f);
        }

        circleCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (bossHealth != null)
        {
            if (other.gameObject.layer == 6)
            {
                bossHealth.TakeDamage(bladeDamage);
            }
        }
    }

}
