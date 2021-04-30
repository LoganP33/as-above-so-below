using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Health = new GameObject[3];
	public static int heal = 3;
    public GameOverMenu GameOverMenu;


    public void Update_Healthbar(int current_health)
    {
       if(current_health < 3)
       {
            Health[2].SetActive(false);
			heal = 2;
       }

        if (current_health < 2)
        {
            Health[1].SetActive(false);
			heal = 1;
        }

        if (current_health < 1)
        {
            Health[0].SetActive(false);
			heal = 0;
            GameOverMenu.GameOver();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            HealthBar.heal = 3;
        }
    }

}
