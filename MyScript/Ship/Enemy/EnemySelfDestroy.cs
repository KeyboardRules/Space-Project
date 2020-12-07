using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelfDestroy : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool destroy_after_time_out;
    [SerializeField] private float time_exist;
    void Start()
    {
        if (destroy_after_time_out)
        {
            Destroy(this.gameObject, time_exist);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (col.GetComponent<ShipHealth>())
            {
                col.GetComponent<ShipHealth>().DealDamage(damage);
                GetComponent<ShipHealth>().DealDamage(GetComponent<ShipHealth>().GetMaxHealth());
            }
        }
    }
}
