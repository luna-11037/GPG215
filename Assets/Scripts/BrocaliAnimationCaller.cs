using UnityEngine;
using UnityEngine.InputSystem;

public class BrocaliAnimationCaller : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Animator animatorReference;

    public BrocaliAnimationCaller(Animator animator)
    {
        this.animatorReference = animator; //assigns temp var to construct
    }

    public void fireBrocaliDamage()
    {
        animatorReference.SetTrigger("TriggerDamage");
    }

    public void fireBrocaliAttack()
    {
        animatorReference.SetTrigger("TriggerAttack");
    }

    public void fireForceIdle()
    {
        animatorReference.SetBool("TriggerIdle", true);
    }



}
