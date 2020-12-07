using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float ship_speed = 3;
    public float ship_rotation = 3;
    public float distance_between = 4;

    GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CheckDistance())
        {
            Rotate();
            Moving();
        }
    }
    bool CheckDistance()
    {
        if (playerShip)
        {
            if (Vector2.Distance(transform.position, playerShip.transform.position) > distance_between)
            {
                return true;
            }
        }
        return false;
    }
    void Rotate()
    {
        Vector3 difference = playerShip.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f, Time.deltaTime * ship_rotation)));
    }
    void Moving()
    {
        transform.Translate(Vector2.up * ship_speed * Time.deltaTime);
    }
}
