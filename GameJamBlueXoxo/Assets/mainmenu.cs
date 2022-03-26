using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsMenu;
    public void StratGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void closeSettings()
    {
        settingsMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
