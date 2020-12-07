using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] [Range(0, 25)] int health;
    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && col.GetComponentInChildren<ShipHealth>())
        {
            FindObjectOfType<AudioManager>().PlaySound("Power Up");
            col.GetComponentInChildren<ShipHealth>().RecoverHealth(health);
            Destroy(this.gameObject);
        }
    }
}
