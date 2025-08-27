using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;

    public Slider _healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);
        Debug.Log($"[PLAYER] HP: {currentHealth}");
        UpdateUI();
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
    public void UpdateUI()
    {
        if (_healthBar != null)
        {
            _healthBar.maxValue = maxHealth;
            _healthBar.value = currentHealth;
        }
    }
}


