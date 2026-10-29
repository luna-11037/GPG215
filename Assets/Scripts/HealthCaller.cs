using UnityEngine;
using UnityEngine.InputSystem;

public class HealthCaller : MonoBehaviour
{
    private HealthScript healthScriptRef = new HealthScript();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthScriptRef.SetHealth(50);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(healthScriptRef.GetHealth());

    }
}
