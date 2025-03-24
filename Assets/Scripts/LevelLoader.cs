using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public StringEventChannel onLevelEnded; // Référence à l'event channel

    private void OnEnable()
    {
        if (onLevelEnded != null)
        {
            onLevelEnded.OnEventRaised += LoadNextLevel;
        }
    }

    private void OnDisable()
    {
        if (onLevelEnded != null)
        {
            onLevelEnded.OnEventRaised -= LoadNextLevel;
        }
    }

    private void LoadNextLevel(string levelName)
    {
        if (!string.IsNullOrEmpty(levelName))
        {
            Debug.Log("Chargement du niveau : " + levelName);
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogError("Nom du niveau invalide !");
        }
    }
}
