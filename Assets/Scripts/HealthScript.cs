using System;
using UnityEngine;

//HealthScript mightttt throw an error about ExtensionOfNativeClass, this is just because it doesn't inhrerit monobehaviour or Scriptable Object in Public Class Healthscript, doesn't really matter
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
