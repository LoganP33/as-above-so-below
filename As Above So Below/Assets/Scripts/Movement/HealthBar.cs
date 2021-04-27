using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Health = new GameObject[3];


    public void Update_Healthbar(int current_health)
    {
       if(current_health < 3)
       {
            Health[2].SetActive(false);
       }

        if (current_health < 2)
        {
            Health[1].SetActive(false);
        }

        if (current_health < 1)
        {
            Health[0].SetActive(false);
        }
    }

}
