using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeapon : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && col.GetComponent<PlayerLevel>())
        {
            FindObjectOfType<AudioManager>().PlaySound("Power Up");
            col.GetComponent<PlayerLevel>().LevelUp();
            Destroy(this.gameObject);
        }
    }
}
