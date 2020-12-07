using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    public float ship_speed = 10;
    public float ship_rotation = 3;
    public float distance_to_stop_tracking = 3;

    GameObject playerShip;
    bool tracking=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        if (!playerShip)
        {
            playerShip = GameObject.FindGameObjectWithTag("Player");
        }
        if (playerShip && Vector2.Distance(transform.position, playerShip.transform.position) <= distance_to_stop_tracking)
        {
            tracking = false;
        }
        Tracking();
        Moving();
    }
    void Tracking()
    {
        if (tracking && playerShip)
        {
            Vector3 difference = playerShip.transform.position - transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f, Time.deltaTime * ship_rotation)));
        }
    }
    void Moving()
    {
        transform.Translate(Vector2.up * ship_speed * Time.deltaTime);
    }
    public void ResetTracking()
    {
        tracking = true;
    }
}
