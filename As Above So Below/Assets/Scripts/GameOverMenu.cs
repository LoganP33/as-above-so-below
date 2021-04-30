using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static GameObject screen;

    public static void GameOver() {
        screen = GameObject.FindWithTag("Gameover_Screen");
        screen.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene("Main Level");
    }

    public void Menu() {
        //Load previous scene --> The previous scene should be the Main Menu Scene
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit() {
        Application.Quit();
    }
}
