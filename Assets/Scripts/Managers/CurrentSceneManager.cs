using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isDebugConsoleOpened = false;

    [Header("Listen to events")]
    public StringEventChannel onLevelEnded;
    public BoolEventChannel onDebugConsoleOpenEvent;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        if (onLevelEnded != null)
            onLevelEnded.OnEventRaised += LoadScene;
        else
            Debug.LogWarning("onLevelEnded is not assigned.");

        if (onDebugConsoleOpenEvent != null)
            onDebugConsoleOpenEvent.OnEventRaised += OnDebugConsoleOpen;
        else
            Debug.LogWarning("onDebugConsoleOpenEvent is not assigned.");
    }

    public void LoadScene(string sceneName)
    {
        if (UtilsScene.DoesSceneExist(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log($"Unknown scene named {sceneName}. Please add the scene to the build settings.");
        }
    }

    public void LoadScene(int sceneIndex)
    {
        if (UtilsScene.DoesSceneExist(sceneIndex))
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.Log($"Unknown scene with index {sceneIndex}. Please add the scene to the build settings.");
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void RestartLastCheckpoint()
    {
        Debug.Log("RestartLastCheckpoint");
        // Refill life to full
        // Position to last checkpoint
        // Remove menu
        // Reset Rigidbody
        // Reactivate Player movements
        // Reset Player's rotation
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnDisable()
    {
        if (onLevelEnded != null)
            onLevelEnded.OnEventRaised -= LoadScene;

        if (onDebugConsoleOpenEvent != null)
            onDebugConsoleOpenEvent.OnEventRaised -= OnDebugConsoleOpen;
    }

    private void OnDebugConsoleOpen(bool debugConsoleOpened)
    {
        isDebugConsoleOpened = debugConsoleOpened;
    }
    public void StartGame()
{
    string firstLevelSceneName = "Level1"; // Assure-toi que le nom de la scène du premier niveau est correct
    if (UtilsScene.DoesSceneExist(firstLevelSceneName))
    {
        SceneManager.LoadScene(firstLevelSceneName); // Charge la scène du premier niveau
    }
    else
    {
        Debug.LogError($"La scène {firstLevelSceneName} n'a pas été trouvée. Assurez-vous qu'elle est ajoutée aux paramètres de construction.");
    }
}

}
