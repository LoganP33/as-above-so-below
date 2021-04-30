
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
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        if(hitInfo.name == "Layer1" || hitInfo.name == "Player" || hitInfo.name == "Default")
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