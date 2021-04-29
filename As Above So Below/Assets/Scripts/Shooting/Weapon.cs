using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Upgrade_Type
{
	public int damage;
	public float fireRate;
	public GameObject wpn_sprite;
	public Transform firePoint;
	public float timeToFire;
	public AudioSource gun_sound;
}

public class Weapon : MonoBehaviour
{
	public int current_upgrade_lvl;
	public Upgrade_Type[] Upgrades = new Upgrade_Type[4];
	//firePoint transform, where the bullet exits the gun
	public Transform firePoint;
	//The sprite used for the bullet
	public GameObject bulletPrefab;
	//How many shots the weapon can fire, 0 for single burst, 2 for 2 shots a second on mouse down, etc.
	public float fireRate = 0;
	//Used so that bullets cannot hit the player or other raycasts
	public LayerMask whatToHit;
	//How fast that the weapon fires the fireRate
	public float timeToFire = 0;
	public AudioSource gun_sound;
	public static int damage;



	void Start()
    {
		//Disabling all weapon sprites besides the first one and making current upgrade level 0 (start with pistol)
		current_upgrade_lvl = 0;
		Upgrades[0].wpn_sprite.SetActive(true);
		Upgrades[1].wpn_sprite.SetActive(false);
		Upgrades[2].wpn_sprite.SetActive(false);
		Upgrades[3].wpn_sprite.SetActive(false);

		//Making all weapon stats be the first weapon
		damage = Upgrades[0].damage;
		firePoint = Upgrades[0].firePoint;
		timeToFire = Upgrades[0].timeToFire;
		fireRate = Upgrades[0].fireRate;
		gun_sound = Upgrades[0].gun_sound;

		update_upgrades(current_upgrade_lvl);
	}


	// Update is called once per frame
	void Update()
	{
		if(fireRate == 0)
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

	public void update_upgrades(int current_upgrade_lvl)
    {
		if(current_upgrade_lvl < 4 && current_upgrade_lvl != 0)
        {
			fireRate = Upgrades[current_upgrade_lvl].fireRate;
			damage = Upgrades[current_upgrade_lvl].damage;
			firePoint = Upgrades[current_upgrade_lvl].firePoint;
			timeToFire = Upgrades[current_upgrade_lvl].timeToFire;
			gun_sound = Upgrades[current_upgrade_lvl].gun_sound;
			Upgrades[current_upgrade_lvl].wpn_sprite.SetActive(true);
			Upgrades[current_upgrade_lvl - 1].wpn_sprite.SetActive(false);
		}		

	}

	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Debug.Log(gun_sound);
		gun_sound.Play();
	}
}