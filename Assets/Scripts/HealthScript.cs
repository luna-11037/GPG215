using System;
using UnityEngine;

public class HealthScript
{
    private int health = 100;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SetHealth(int newHealth)
    {
        this.health = newHealth;
    }

    public int GetHealth()
    {
        return health;
    }

}
