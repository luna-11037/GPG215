using UnityEngine;
using UnityEngine.InputSystem;

public class BrocaliAnimationCaller : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject animatorReference;

    public BrocaliAnimationCaller(GameObject animator)
    {
        this.animatorReference = animator; //assigns temp var to construct
    }

    public void fireBrocaliDamage()
    {
        animatorReference.gameObject.GetComponent<Animator>().SetTrigger("TriggerDamage");
    }

    public void fireBrocaliAttack()
    {
        animatorReference.gameObject.GetComponent<Animator>().SetTrigger("TriggerAttack");
    }

    public void fireForceIdle()
    {
        animatorReference.gameObject.GetComponent<Animator>().SetBool("TriggerIdle", true);
    }



}
