using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{

    public int rotationOffset = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Subtracting the position of the player from the mouse posistion
        difference.Normalize(); //Normalizing the vector, sum of vector = 1

        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Finding the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + rotationOffset);

    }
}
