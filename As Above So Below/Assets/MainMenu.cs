using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Load next scene --> Scene 0 should be Main Menu, Scene 1 should be the game scene
        SceneManager.LoadScene("Main Level")
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
