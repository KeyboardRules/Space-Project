using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    [SerializeField] private int max_health = 10;
    [SerializeField] private int min_health = 0;
    [SerializeField] private int recovery_health = 1;
    [SerializeField] private float recovery_time = 1;
    [SerializeField] private float recovery_countdown = 5;
    [SerializeField] private float disable_time = 20;
    [SerializeField] private BarSetting bar;
    
    int current_health;
    float damage_taken;
    bool disable;
    float time_recovery;
    float countdown_recovery;
    float time_disable;

    Animator ani;
    // Update is called once per frame
    private void Start()
    {
        ani = GetComponent<Animator>();
        current_health = max_health;
        if (bar) bar.SetMaxValue(max_health,current_health);
    }
    void Update()
    {
        Disable();
        Recovery();

        if (damage_taken >= 0)
        {
            damage_taken -= Time.deltaTime;
        }
        if (ani)
        {
            ani.SetFloat("DamageTaken", damage_taken);
            ani.SetBool("Disable", disable);
        }
    }
    public void DealDamage(int damage)
    {
        if (damage > 0)
        {
            if (damage_taken <= 0.28f)
            {
                damage_taken += 0.2f;
            }
            time_recovery = recovery_time;
            countdown_recovery = recovery_countdown;
            current_health -= damage;
            if (current_health < min_health)
            {
                current_health = min_health;
            }
            if (bar && !disable) bar.SetCurrentValue(current_health);
        }
        else
        {
            Debug.Log("Error damage recive smaller than zero");
        }
    }
    public bool isDisable()
    {
        return disable;
    }
    private void RecoverHealth(int recover)
    {
        if (recover > 0)
        {
            if (time_recovery >= recovery_time)
            {
                current_health += recover;
                if (current_health > max_health)
                {
                    current_health = max_health;
                }
                time_recovery = 0;
            }
            if (current_health != max_health)
            {
                time_recovery += Time.deltaTime;
            }
            if (bar && !disable) bar.SetCurrentValue(current_health);
        }
        else
        {
            Debug.Log("Error damage heal smaller than zero");
        }
    }
    private void Disable()
    {
        if (current_health == min_health && !disable)
        {
            disable = true;
        }
        if(disable)
        {
            time_disable += Time.deltaTime;
            if (time_disable >= disable_time)
            {
                time_disable = 0;
                disable = false;
            }
        }
    }
    private void Recovery()
    {
        if (countdown_recovery > 0)
        {
            countdown_recovery -= Time.deltaTime;
        }
        else
        {
            RecoverHealth(recovery_health);
        }
    }
}
