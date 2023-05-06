using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool gameIsPaused = false;
    [SerializeField] private GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void AppQ()
    {
        Application.Quit();
        print("q");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
        print(Menu);
    }
    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
    void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}

