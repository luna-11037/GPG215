using Unity.VisualScripting;
using UnityEngine;

public class OnSplashEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem splashEffect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the splash effect
            ParticleSystem splashEffect = GetComponent<ParticleSystem>();
            if (splashEffect != null)
            {
                splashEffect.Play(); 
            }
        }

    }
}
