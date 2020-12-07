using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RocketItems : MonoBehaviour
{
    [SerializeField] [Range(1, 3)] int rockets = 0;
    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && col.GetComponentInChildren<PlayerRocket>())
        {
            FindObjectOfType<AudioManager>().PlaySound("Power Up");
            if(col.GetComponentInChildren<PlayerRocket>()) col.GetComponentInChildren<PlayerRocket>().AddRocket(rockets);
            if (col.GetComponentInChildren<TouchPlayerRocket>()) col.GetComponentInChildren<TouchPlayerRocket>().AddRocket(rockets);
            Destroy(this.gameObject);
        }
    }
}
