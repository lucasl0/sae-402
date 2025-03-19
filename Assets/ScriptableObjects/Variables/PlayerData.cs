using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "ScriptableObjects/Variable/PlayerData")]
public class PlayerData : ScriptableObject
{
     public float currentHealth = 0;
    public float maxHealth = 3;
}