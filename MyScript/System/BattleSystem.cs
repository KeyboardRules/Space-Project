using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    private enum BattleState
    {
        Active,
        Over,
    }
    [SerializeField] private EnemyWave[] wave;
    [SerializeField] private Transform[] spawn_position;
    [SerializeField] private float time_between_wave;
    [SerializeField] private WaveUIController waveUI;
    [SerializeField] private BlackSceneController trans_scene;
    [SerializeField] private GameManger game_manager; 

    float countdown_finish;
    int wave_index;
    BattleState bs;
    // Start is called before the first frame update
    void Start()
    {
        StartBattle();
    }

    // Update is called once per frame
    void Update()
    {
        BattleActive();
        BattleOver();
    }
    private void StartBattle()
    {
        bs = BattleState.Active;
        if (game_manager) game_manager.Wave(wave_index);
        Debug.Log("battle start");
    }
    private Transform RandomPosition()
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(spawn_position.Length);
        return spawn_position[index];
    }
    private void BattleActive()
    {
        
        if (bs == BattleState.Active)
        {
            Debug.Log(wave_index);
            wave[wave_index].UpdateWave(RandomPosition());
            if (wave[wave_index].EndWave())
            {
                wave_index++;
                if (wave_index >= wave.Length)
                {
                    bs = BattleState.Over;
                    Debug.Log("Battle end");
                }
                else
                {
                    if (game_manager) game_manager.Wave(wave_index);
                    FindObjectOfType<AudioManager>().PlayNewTheme(wave[wave_index].theme);
                }
            }
        }
    }
    private void BattleOver()
    {
        if (bs == BattleState.Over)
        {
            if (game_manager) game_manager.EndGame();
        }
    }
    [Serializable]
    private class EnemyWave
    {
        [SerializeField] private List<Enemy> enemies;
        public string theme;
        public void UpdateWave(Transform location)
        {
            Enemy.UpdateEnemy();
            foreach (Enemy enemy in enemies.ToList())
            {
                if (enemy.CheckSpawn())
                {
                    enemies.Remove(enemy);
                }
                else
                {
                    enemy.Spawn(location);
                }
            }
        }
        public bool EndWave()
        {
            if (enemies.Count == 0 && CheckEnemiesOnWave())
            {
                Debug.Log("End wave");
                return true;
            }
            return false;
        }
        private bool CheckEnemiesOnWave()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
    [Serializable]
    private class Enemy
    {
        [SerializeField] GameObject enemy;
        [SerializeField] [Range(0, 100)] int number=0;
        [SerializeField] [Range(0, 20)] float time_between_spawn = 0;
        static int MAX_ENEMY_ON_FIELD=15;
        static List<GameObject> enemy_on_field=new List<GameObject>();

        float time;
        int count;
        public void Spawn(Transform location)
        {
            if (count < number && time >= time_between_spawn && CheckEnemiesOnField())
            {
               // Debug.Log("Install enemy");
                GameObject current_enemy=Instantiate(enemy, location.position, location.rotation);
                enemy_on_field.Add(current_enemy);
                count++;
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
        public bool CheckSpawn()
        {
            if (count == number) return true;
            return false;
        }
        public static void UpdateEnemy()
        {
            if (enemy_on_field.Count > 0)
            {
                foreach (GameObject enemy in enemy_on_field.ToList())
                {
                    if (!enemy)
                    {
                        enemy_on_field.Remove(enemy);
                    }
                }
            }
        }
        private bool CheckEnemiesOnField()
        {
            if (enemy_on_field.Count < MAX_ENEMY_ON_FIELD)
            {
                return true;
            }
            return false;
        }
    }
}
