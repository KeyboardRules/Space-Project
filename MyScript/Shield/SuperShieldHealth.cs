using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShieldHealth : MonoBehaviour
{
    [SerializeField] private int max_health = 10;
    [SerializeField] private int min_health = 0;
    int current_health;

    Animator ani;
    float damage_taken;
    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        ani = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (current_health == min_health)
        {
            Destroy(gameObject);
        }
        if (damage_taken >= 0)
        {
            damage_taken -= Time.deltaTime;
        }
        if (ani) ani.SetFloat("DamageTaken", damage_taken);
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
        }
        else
        {
            Debug.Log("Error damage recive smaller than zero");
        }
    }
    public void RecoverAll()
    {
        current_health = max_health;
    }
}
