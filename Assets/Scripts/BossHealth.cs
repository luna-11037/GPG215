using TMPro;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    [SerializeField] private HealthBarUI healthBar;

    [SerializeField] private TMP_Text winText;

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealthBar(health);
        Debug.Log("Enemy hit! Health: " + health);

        if (health <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        Destroy(this.gameObject);

        winText.text = "You win!";
        GameManager.Instance.EndGame();
    }
}
