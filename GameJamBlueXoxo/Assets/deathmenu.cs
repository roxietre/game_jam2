using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class deathmenu : MonoBehaviour
{
    public GameObject deathMenuUI;
    public GameObject player;
    public GameObject boss;
	private PlayerHealth pl;
    void Update()
    {
        if (!player)
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (player)
        {
            deathMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        if (pl.isDead)
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (!pl.isDead)
        {
            deathMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        if (!boss)
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (boss)
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
