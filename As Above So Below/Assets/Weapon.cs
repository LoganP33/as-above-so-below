using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	//firePoint transform, where the bullet exits the gun
	public Transform firePoint;
	//The sprite used for the bullet
	public GameObject bulletPrefab;
	//How many shots the weapon can fire, 0 for single burst, 2 for 2 shots a second on mouse down, etc.
	public float fireRate = 0;
	//Used so that bullets cannot hit the player or other raycasts
	public LayerMask whatToHit;
	//How fast that the weapon fires the fireRate
	float timeToFire = 0;
	//How far the bullet can travel before despawning
	float bulletDistance = 100;


	// Update is called once per frame
	void Update()
	{
		if (fireRate == 0)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				Shoot();
			}
		}

		else
        {
			if(Input.GetButton("Fire1") && Time.time > timeToFire)
            {
				timeToFire = Time.time + 1 / fireRate;
				Shoot();
            }
        }
	}

	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}