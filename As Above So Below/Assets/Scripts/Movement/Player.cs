using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar HealthBar;
    public Weapon Weapon;
    private bool crossed_checkpoint1 = false;
    private bool crossed_checkpoint2 = false;
    private bool crossed_checkpoint3 = false;
    private bool crossed_checkpoint4 = false;

    public class PlayerStats
    {
        public int Health = 3;
    }

    //Instance of PlayerStats object
    public PlayerStats playerStats = new PlayerStats();

    Renderer rend;
    Color c;

    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    void Update()
    {
        if (transform.position.y <= -20)
            damagePlayer();
    }

    public void setAlpha(float alpha)
    {
        SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>();
        Color newColor;
        foreach (SpriteRenderer child in children)
        {
            newColor = child.color;
            newColor.a = alpha;
            child.color = newColor;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        //If the player collides with an Enemy, take damage
		Debug.Log(col.gameObject.name);
		Debug.Log(playerStats.Health);
        if(col.gameObject.name == "Enemy(Clone)" && playerStats.Health > 0)
        {
            damagePlayer();
            Debug.Log(playerStats.Health);
            StartCoroutine("Invulnerability_Frames");
        }
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Checkpoint1" && crossed_checkpoint1 == false)
		{
			crossed_checkpoint1 = true;
            Weapon.current_upgrade_lvl = 1;
            Weapon.update_upgrades(Weapon.current_upgrade_lvl);
		}
		else if (col.gameObject.name == "Checkpoint2" && crossed_checkpoint2 == false)
        {
            crossed_checkpoint2 = true;
            Weapon.current_upgrade_lvl = 2;
            Weapon.update_upgrades(Weapon.current_upgrade_lvl);
        }

        else if (col.gameObject.name == "Checkpoint3" && crossed_checkpoint3 == false)
        {
            crossed_checkpoint3 = true;
            Weapon.current_upgrade_lvl = 3;
            Weapon.update_upgrades(Weapon.current_upgrade_lvl);
        }

        else if (col.gameObject.name == "Checkpoint4" && crossed_checkpoint4 == false)
        {
            crossed_checkpoint4 = true;
            Weapon.current_upgrade_lvl = 4;
            Weapon.update_upgrades(Weapon.current_upgrade_lvl);
        }
    }

    public void damagePlayer()
    {
        playerStats.Health -= 1;
        HealthBar.Update_Healthbar(playerStats.Health);
        //if health <= 0, kill player
        if (playerStats.Health <= 0)
        {
			PlayerPos.known = 1;
			playerStats.Health = 3;
        }
    }

    IEnumerator Invulnerability_Frames()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        c.a = 0.6f;
        setAlpha(0.6f);
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(3, 6, false);
        c.a = 1f;
        rend.material.color = c;
        setAlpha(1f);
    }
}
