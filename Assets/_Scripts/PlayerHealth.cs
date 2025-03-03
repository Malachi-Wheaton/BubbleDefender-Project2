using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int health = 5;

    void Awake() => instance = this;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Player Health: " + health);
        if (health <= 0)
            Debug.Log("Game Over!");
    }
}


