using UnityEngine;

public class ParticleCollig : MonoBehaviour
{
    public ParticleSystem ps;

    private void Awake(){
        ps.Stop();
    }
    private void OnBecameVisible(){
        ps.Play();
    }

    private void OnBecameInvisible(){
        ps.Stop();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
