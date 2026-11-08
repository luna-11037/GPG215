using PinePie.SimpleJoystick;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private JoystickController joystickController;

    [SerializeField] private float moveSpeed=5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position +=
                moveSpeed * Time.deltaTime * (Vector3)joystickController.InputDirection;
    }
}
