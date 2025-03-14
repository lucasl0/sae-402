using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [Tooltip("Define where the player will spawn if there is an issue")]
    public Vector3 currentSpawnPosition;

    [Tooltip("Define where the player started the level")]
    public Vector3 initialSpawnPosition;
    
    public Vector3Variable lastCheckpointPosition;

    private void Awake()
    {     
        if (lastCheckpointPosition != null && lastCheckpointPosition.CurrentValue != Vector3.zero)
        {
            transform.position = lastCheckpointPosition.CurrentValue;
        }
        else
        {
            lastCheckpointPosition.CurrentValue = transform.position;
        }
        
        currentSpawnPosition = transform.position;
        initialSpawnPosition = transform.position;
    }
}
