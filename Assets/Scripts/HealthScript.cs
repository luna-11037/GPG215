using System;
using TMPro;
using UnityEngine;

//HealthScript mightttt throw an error about ExtensionOfNativeClass, this is just because it doesn't inhrerit monobehaviour or Scriptable Object in Public Class Healthscript, doesn't really matter
public interface IHealth 
{
    public void HandleHealth(float damage)
    {
        
    }

    protected void HandleDeath()
    {
    }

}
