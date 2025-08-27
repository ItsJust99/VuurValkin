using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider _healthBarDragon;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);
        Debug.Log($"Dragon HP: {currentHealth}");
        UpdateUI();
    }

    //Word gehandeld in trunbased
    public bool IsDead()
    {
        return currentHealth <= 0;
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    void UpdateUI()
    {
        if (_healthBarDragon != null)
        {
            _healthBarDragon.maxValue = maxHealth;
            _healthBarDragon.value = currentHealth;
        }
    }
}
