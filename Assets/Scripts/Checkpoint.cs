using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider2D bc2d;
    public Vector3Variable lastCheckpointposition;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerSpawn playerSpawn = collision.GetComponent<PlayerSpawn>();
            if (playerSpawn != null)
            {
                animator.SetTrigger("IsActivated");
                playerSpawn.currentSpawnPosition = transform.position;
                bc2d.enabled = false;
                lastCheckpointposition.CurrentValue = transform.position;
            }
        }
    }
}
