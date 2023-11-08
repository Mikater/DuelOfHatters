using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void SinglePlayer() 
    {
        SceneManager.LoadScene(1);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void DemoLvl()
    {
        SceneManager.LoadScene(2);
    }
    public void MultiPlayerLobby()
    {
        SceneManager.LoadScene(3);
    }
}
