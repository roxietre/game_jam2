using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public string levelToLoad;
    public void StratGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Settings()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
