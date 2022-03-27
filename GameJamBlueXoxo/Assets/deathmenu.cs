using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class deathmenu : MonoBehaviour
{
    public GameObject deathMenuUI;
    public GameObject player;
    public GameObject boss;
    void Update()
    {
        if (!player || !boss)
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (player || boss)
        {
            deathMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
