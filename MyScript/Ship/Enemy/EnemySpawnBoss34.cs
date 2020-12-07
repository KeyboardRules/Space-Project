using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnBoss34 : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] int limited_enemy;
    [SerializeField] float time_between_spawn;
    [SerializeField] bool defense;
    // Start is called before the first frame update

    float countdown_spawn;
    List<GameObject> current_enemy;
    // Update is called once per frame
    private void Start()
    {
        current_enemy = new List<GameObject>();
        countdown_spawn = time_between_spawn;
    }
    void Update()
    {
        if (countdown_spawn >= time_between_spawn)
        {
            CheckList();
            Spawning();
            countdown_spawn = 0;
        }
        countdown_spawn += Time.deltaTime;
    }
    void Spawning()
    {
        if (current_enemy.Count < limited_enemy)
        {
            System.Random rd = new System.Random();
            int index = rd.Next(enemies.Length);
            GameObject add_enemy = Instantiate(enemies[index], transform.position, Quaternion.identity);
            if (add_enemy.GetComponent<EnemyTrakingDrone>())
            {
                if (defense)
                {
                    add_enemy.GetComponent<EnemyTrakingDrone>().SetShip(gameObject);
                }
                else
                {
                    add_enemy.GetComponent<EnemyTrakingDrone>().SetShip(GameObject.FindGameObjectWithTag("Player"));
                }
            }
            current_enemy.Add(add_enemy);
        }
    }
    void CheckList()
    {
        foreach(GameObject enemy in current_enemy.ToList())
        {
            if (!enemy)
            {
                current_enemy.Remove(enemy);
            }
        }
    }
    void OnDestroy()
    {
        foreach(GameObject enemy in current_enemy.ToList())
        {
            ShipHealth health = enemy.GetComponent<ShipHealth>();
            health.DealDamage(health.GetMaxHealth());
        }
    }
}
