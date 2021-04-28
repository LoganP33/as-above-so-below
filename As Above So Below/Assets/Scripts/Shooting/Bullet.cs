
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage;
    public Rigidbody2D rb;
    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        damage = Weapon.damage;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            Debug.Log("Weapon dmg: " + damage);
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        if(hitInfo.name == "Tilemap" || hitInfo.name == "Player")
        {
            Destroy(gameObject);
        }


    }
    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }

}