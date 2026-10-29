using System;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

//HealthScript mightttt throw an error about ExtensionOfNativeClass, this is just because it doesn't inhrerit monobehaviour or Scriptable Object in Public Class Healthscript, doesn't really matter
public class HealthScript : MonoBehaviour 
{
    public float health = 100f;

    [SerializeField] private HealthBarUI healthBar;

    [SerializeField] private TMP_Text loseText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void HandleHealth(float damage)
    {
        health -= damage;

        healthBar.SetHealthBar(health);

        if (health <= 0)
        {
            HandleDeath();
        }
    }

    public float GetHealth()
    {
        return health;
    }

    private void HandleDeath()
    {
        loseText.text = "You lose.";
        GameManager.Instance.EndGame();
    }

}
