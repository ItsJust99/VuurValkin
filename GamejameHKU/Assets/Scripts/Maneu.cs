using UnityEngine;
using UnityEngine.SceneManagement;

public class Maneu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void RMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
