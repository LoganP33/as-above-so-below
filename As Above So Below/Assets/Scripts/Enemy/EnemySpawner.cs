using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject enemy;
    float randX;
    public float spawnRate = 3f;
    float nextSpawn = 0;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(Time.time > nextSpawn && enemies.Length < 5)
        {
            nextSpawn = Time.time + spawnRate;
            Vector2 v2Pos = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector2(1.5f, 1.1f));
            Instantiate(enemy, v2Pos, Quaternion.identity);
        }
    }


}
