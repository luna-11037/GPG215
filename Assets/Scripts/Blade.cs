using UnityEngine;

public class Blade : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlashing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlashing();
        }   
    }

    private void StartSlashing()
    {

    }

    private void StopSlashing()
    {

    }
}
