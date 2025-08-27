using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Debug.Log($"[PLAYER] HP: {currentHealth}");
        UpdateUI();
    }

    //Word gehendeld in trunbased script
    public bool IsDead()
    {
        return currentHealth <= 0;
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene("Loose");
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


