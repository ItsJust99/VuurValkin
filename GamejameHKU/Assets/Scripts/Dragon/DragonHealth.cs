using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private void Update()
    {
        if (currentHealth == 0)
        {
            LoadNextScene();
        }
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
    
    private void LoadNextScene()
    {
        SceneManager.LoadScene("WIn");
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
