using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private Level[] level;
    [SerializeField] private Transform[] all_positions;

    int current_level;
    bool level_up;
    // Update is called once per frame
    private void Start()
    {
        level_up = true;
    }
    void Update()
    {
        UpdateLevel();
    }
    public void LevelUp()
    {
        if (current_level < level.Length-1)
        {
            current_level++;
            level_up = true;
        }
    }
    private void UpdateLevel()
    {
        if (level_up)
        {
            foreach (Transform position in all_positions)
            {
                //Debug.Log(position);
               // Transform[] all_childs = position.GetComponentsInChildren<Transform>(); get all component even in deep of the btree
                foreach(Transform child in position)
                {
                    if (child != position)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
            level[current_level].UpdateLevel();
            level_up = false;
        }
    }
    [Serializable]
    private class Level
    {
        [SerializeField] private Turret[] turrets;
        public void UpdateLevel()
        {
            foreach (Turret tur in turrets)
            {
                tur.UpdateTurret();
            }
        }
    }
    [Serializable]
    private class Turret
    {
        [SerializeField] private GameObject turret;
        [SerializeField] private Transform turret_position;
        public void UpdateTurret()
        {
            GameObject insert_turret=Instantiate(turret,turret_position.position , Quaternion.identity);
            insert_turret.transform.SetParent(turret_position);
            insert_turret.transform.localPosition = Vector3.zero;
        }
    }
}
