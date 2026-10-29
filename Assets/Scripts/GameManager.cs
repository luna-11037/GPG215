using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject endScreen;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (endScreen != null)
        {
            endScreen.SetActive(false);
        }
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}