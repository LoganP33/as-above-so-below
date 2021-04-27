using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar HealthBar;

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
            damagePlayer(10);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        //If the player collides with an Enemy, take damage
        if(col.gameObject.name == "Enemy(Clone)" && playerStats.Health > 0)
        {
            damagePlayer(10);
            Debug.Log(playerStats.Health);
            StartCoroutine("Invulnerability_Frames");
        }
        Debug.Log(col.gameObject.name);
        
    }

    public void damagePlayer(int damage)
    {
        playerStats.Health -= 1;
        HealthBar.Update_Healthbar(playerStats.Health);
        //if health <= 0, kill player
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    IEnumerator Invulnerability_Frames()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(3, 6, false);
        c.a = 1f;
        rend.material.color = c;
    }
}
