using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI Screens")]
    public GameObject gameOverScreen;

    [Header("Player Reference")]
    public GameObject player;

    [Header("Listen to Event Channels")]
    public VoidEventChannel onPlayerDeath;

    private void OnEnable()
    {
        onPlayerDeath.OnEventRaised += OnGameOver;
    }

    private void OnDisable()
    {
        onPlayerDeath.OnEventRaised -= OnGameOver;
    }

    private void Start()
    {
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
    }

    public void OnGameOver()
    {
        Debug.Log("<size=15><color=#FF0000><b>GameOver!</b></color></size>");
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);

        LockPlayerMovement(true);
        FreezePlayerPhysics();
    }

    private void LockPlayerMovement(bool lockMovement)
    {
        if (player != null)
        {
            var playerController = player.GetComponent<PlayerMovement>();
            if (playerController != null)
            {
                playerController.enabled = !lockMovement;
            }
        }
    }

    private void FreezePlayerPhysics()
    {
        if (player != null)
        {
            var rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = false;
            }
        }
    }    
}
