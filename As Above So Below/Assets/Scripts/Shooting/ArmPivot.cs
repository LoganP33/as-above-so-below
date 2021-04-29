using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPivot : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        //Converting screeen position of mouse to world position of mouse
        Vector3 difference = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        //if arm is on left side of graph
        if(rotation_z < -90 || rotation_z > 90)
        {
            
            //if player is facing right
            if(Player.transform.eulerAngles.y == 0)
            {
                //flips the hand
                transform.localRotation = Quaternion.Euler(180, 0, -rotation_z);
            }

            else if(Player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotation_z);
            }
        }
    }
}