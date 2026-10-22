using UnityEngine;

public class ScriptableStats : MonoBehaviour
{
    [Header("Layer")]
    public LayerMask PlayerLayer;

    [Header("Movement")]

    public float maxSpeed = 15f;
    public float acceleration = 3.5f;

    public float groundDeceleration = 1.0f;
    public float airDeceleration = 1.0f;
    
    public float fallAcceleration = 0.5f;
    public float maxFallSpeed = 30f;

    public float groundingForce = -1.5f;

    public float jumpPower = 4f;

    public float jumpEndedEarlyGravity = 3f;

    public float jumpBuffer = 0.25f;
    public float coyoteTime = 0.2f;
}
