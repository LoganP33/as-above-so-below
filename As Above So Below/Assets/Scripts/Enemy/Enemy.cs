using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public int health = 100;

	public GameObject deathEffect;
	public GameObject Player;

	private float moveSpeed = 3f;
	private float distanceToPlayer;

    public void Start()
    {
		deathEffect = GameObject.Find("enemy-death-4");
		Player = GameObject.FindGameObjectWithTag("Player");
	}

    public void Update()
    {
		distanceToPlayer = Vector3.Distance(this.transform.position, Player.transform.position);
		if(distanceToPlayer <= 7)
        {
			MoveToPlayer();
        }
    }

    public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}

	void MoveToPlayer()
    {
		if (Player.transform.position.x < this.transform.position.x)
		{
			this.transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
		}
		else if (Player.transform.position.x >= this.transform.position.x)
		{
			this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
		}
	}
}