using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float azarX;
    Vector2 dondeSpawnear;
    public float spawnrate = 2f;
    float proximoSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > proximoSpawn)
        {
            proximoSpawn = Time.time + spawnrate;
            azarX = Random.Range(-8.4f, 8.4f);
            dondeSpawnear = new Vector2(azarX, transform.position.y);
            Instantiate(enemy, dondeSpawnear, Quaternion.identity);
            
        }
    }
}
