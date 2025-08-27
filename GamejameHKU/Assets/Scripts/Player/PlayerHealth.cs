using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);
        Debug.Log($"[PLAYER] HP: {currentHealth}");
    }

    //Word gehendeld in trunbased script
    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
