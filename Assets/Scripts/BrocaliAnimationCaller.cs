using UnityEngine;
using UnityEngine.InputSystem;

public class BrocaliAnimationCaller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject animatorReference;
    private bool runOnce = false;
    void Start()
    {
        //Animator animator = GetComponent<Animator>(); //gets animator component in rig 

    }

    // Update is called once per frame
    void Update()
    {
        if ((Keyboard.current.wKey.isPressed) && animatorReference != null) 
        {
            Debug.Log("anim trigged");
            animatorReference.gameObject.GetComponent<Animator>().SetBool("TriggerAttack", true);

        }
        else
        {
            animatorReference.gameObject.GetComponent<Animator>().SetBool("TriggerAttack", false);
        }
    }
}
