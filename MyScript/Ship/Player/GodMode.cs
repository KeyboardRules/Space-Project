using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    ShipHealth ship_health;
    private void Start()
    {
        ship_health = GetComponent<ShipHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (ship_health.enabled) ship_health.enabled = false;
            else ship_health.enabled = true;
        }
    }
}
