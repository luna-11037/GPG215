using System;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    public float width;
    [SerializeField] private float height;

    private float health;
    private float maxHealth = 100f;

    [SerializeField] private RectTransform healthBar;

    public void SetHealthBar(float newHealth)
    {
        health = newHealth;
        float newWidth = (health / maxHealth) * width;

        healthBar.sizeDelta = new Vector2(newWidth, height);
    }
}
