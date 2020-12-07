using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBoss2 : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    public float speed;

    float timeSpawn;

    // Update is called once per frame
    void Update()
    {
        if (timeSpawn >= spawnTime)
        {
            Spawning();
            timeSpawn = 0;
        }
        else
        {
            timeSpawn += Time.deltaTime;
        }
    }
    void Spawning()
    {
        GameObject spawnObject = Instantiate(enemy, transform.position, transform.rotation);
        spawnObject.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
