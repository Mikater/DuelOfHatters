using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlMenuScript : MonoBehaviour
{
    public GameObject PauseWindow;

    public void PauseGame()
    {
        PauseWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        PauseWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoNextLvl()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLvl()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }
}
