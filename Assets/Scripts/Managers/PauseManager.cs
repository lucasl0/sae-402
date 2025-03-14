using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    [Header("Broadcast event channels")]
    public BoolEventChannel onTogglePauseEvent;

    [Header("Listen to event channels")]
    public BoolEventChannel onDebugConsoleOpenEvent;

    [Header("UI Buttons")]
    public Button restartButton;
    public Button mainMenuButton;
    bool isGamePaused = false;
    bool isDebugConsoleEnabled = false;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Start()
{
    if (restartButton != null)
    {
        restartButton.onClick.AddListener(RestartLevel);
    }
    else
    {
        Debug.LogError("restartButton n'est pas assigné dans l'inspecteur !");
    }

    if (mainMenuButton != null)
    {
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }
    else
    {
        Debug.LogError("mainMenuButton n'est pas assigné dans l'inspecteur !");
    }
}


    private void OnEnable()
    {
        onDebugConsoleOpenEvent.OnEventRaised += TogglePauseDebug;
    }

    void Update()
    {
        if (!isDebugConsoleEnabled && Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            TogglePause(isGamePaused);
        }

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        onTogglePauseEvent.Raise(false);
        pauseMenuUI.SetActive(false);
    }

    void Pause(bool displayPauseMenuUI = true)
    {
        Time.timeScale = 0f;
        onTogglePauseEvent.Raise(true);
        if (displayPauseMenuUI)
        {
            pauseMenuUI.SetActive(true);
        }
        Application.targetFrameRate = 30;
    }

    void TogglePause(bool pauseGame)
    {
        if (!pauseGame)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void TogglePauseDebug(bool pauseGame)
    {
        isDebugConsoleEnabled = !isDebugConsoleEnabled;
        if (!pauseGame)
        {
            Resume();
        }
        else
        {
            Pause(false);
        }
    }

    private void OnDisable()
    {
        onDebugConsoleOpenEvent.OnEventRaised -= TogglePauseDebug;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
