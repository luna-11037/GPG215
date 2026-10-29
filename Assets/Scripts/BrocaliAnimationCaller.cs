using UnityEngine;
using UnityEngine.InputSystem;

public class BrocaliAnimationCaller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject animatorReference;
    [SerializeField] private Animator animator;

    private int hitHash;
    private int attackHash;

    void Start()
    {
        animator = GetComponent<Animator>(); //gets animator component in rig 

        hitHash = Animator.StringToHash("Base Layer.Hit");
        attackHash = Animator.StringToHash("Base Layer.Attack");
    }

    public void PlayHitAnimation()
    {
        animator.Play(hitHash);
    }

    public void PlayAttackAnimation()
    {
        animator.Play(attackHash);
    }
}
