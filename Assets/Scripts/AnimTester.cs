using UnityEngine;
using UnityEngine.InputSystem;

public class AnimTester : MonoBehaviour
{
    [SerializeField] private GameObject AnimReference;
    private BrocaliAnimationCaller animController; //creates field for later use
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animController = new BrocaliAnimationCaller(AnimReference); //sets variable to anim reference
   
    }

    // Update is called once per frame
    void Update()
    {
        if ((Keyboard.current.wKey.isPressed))
        {
            animController.fireBrocaliAttack();
        }
        if ((Keyboard.current.sKey.isPressed))
        {
            animController.fireBrocaliDamage();
        }
        if ((Keyboard.current.dKey.isPressed))
        {
            animController.fireForceIdle();
        }
    }
}
