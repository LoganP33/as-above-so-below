using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public HealthBar HealthBar;
    public Weapon Weapon;
    private bool crossed_checkpoint1 = false;
    private bool crossed_checkpoint2 = false;
    private bool crossed_checkpoint3 = false;
    private bool crossed_checkpoint4 = false;
    private bool can_be_hit;
    public GameObject screen;
    public TMPro.TextMeshProUGUI screen_text;

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
        playerStats.Health = 3;
        can_be_hit = true;
    }

    void Update()
    {
        if (transform.position.y <= -20)
        {
            playerStats.Health = 0;
            HealthBar.Update_Healthbar(playerStats.Health);
            screen.SetActive(true);
        }
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
        if (col.gameObject.tag == "Enemy" && playerStats.Health > 1 && can_be_hit == true)
        {
           can_be_hit = false;
           damagePlayer();
           StartCoroutine("Invulnerability_Frames");
        }
        else if(col.gameObject.tag == "Enemy" && playerStats.Health == 1 && can_be_hit == true)
        {
            damagePlayer();
            screen.SetActive(true);
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
            screen_text.text = "YOU WIN!";
            screen.SetActive(true);
        }
    }

    public void damagePlayer()
    {
        playerStats.Health -= 1;
        HealthBar.Update_Healthbar(playerStats.Health);
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
        can_be_hit = true;
    }
}
