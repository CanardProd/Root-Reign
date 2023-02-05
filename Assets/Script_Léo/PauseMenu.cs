using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioClip buttonClickSound;
    public GameObject objectToChange;

    private AudioSource audioSource;
    private float lastEscapePressTime = 0f;
    private float escapePressDelay = 5f;
    private bool gameStarted = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

// Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            lastEscapePressTime = Time.time;
        }

        if (Hinput.anyGamepad.start.justReleased && Time.time - lastEscapePressTime > escapePressDelay)
        {
            if (GameIsPaused)
            { 
                Resume();
            }
            else
            { 
                Pause(); 
            }
        }
    }

    public void Resume()
    {
        PlayButtonClickSound();
        objectToChange.transform.localScale = new Vector3(1, 1, 1);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        objectToChange.transform.localScale = new Vector3(0, 0, 0);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartLevel()
    {
        PlayButtonClickSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        PlayButtonClickSound();
        Application.Quit();
    }

    private void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound, 0.7F);
    }
}