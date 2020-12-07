using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] private int max_health=10;
    [SerializeField] private int min_health=0;
    [SerializeField] private GameObject explosion;
    [SerializeField] private BarSetting bar;
    [SerializeField] private string explosion_sound;

    private int current_health;
    Animator ani;
    float damage_taken;
    private void Start()
    {
        ani = GetComponent<Animator>();
        current_health = max_health;
        if (bar) bar.SetMaxValue(max_health,current_health);
    }
    private void Update()
    {
        if (current_health == min_health)
        {
            FindObjectOfType<AudioManager>().PlaySound(explosion_sound);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (damage_taken >= 0)
        {
            damage_taken -= Time.deltaTime;
        }
        if(ani) ani.SetFloat("DamageTaken", damage_taken);
    }
    public int GetMaxHealth()
    {
        return max_health;
    }

    public void DealDamage(int damage)
    {
        if (damage > 0)
        {
            current_health -= damage;
            if (current_health < min_health)
            {
                current_health = min_health;
            }
            if (damage_taken <= 0.28f)
            {
                damage_taken += 0.2f;
            }
            if (bar) bar.SetCurrentValue(current_health);
        }
        else
        {
            Debug.Log("Error damage recive smaller than zero");
        }
    }
    public void RecoverHealth(int recover)
    {
        if (recover > 0)
        {
            current_health += recover;
            if (current_health > max_health)
            {
                current_health = max_health;
            }
            if (bar) bar.SetCurrentValue(current_health);
        }
        else
        {
            Debug.Log("Error damage heal smaller than zero");
        }
    }
}
