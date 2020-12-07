using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrakingDrone : MonoBehaviour
{
    public float speed;
    public float rotation_speed;
    public float distance_closest;
    public float distance_farthest;

    GameObject Ship;
    void Update()
    {
        Tracking();
        Moving();
    }
    public void SetShip(GameObject ship)
    {
        Ship = ship;
    }
    void Tracking()
    {
        if (Ship)
        {
            Vector3 difference = Ship.transform.position - transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg)-90f , Time.deltaTime * rotation_speed)));
        }
    }
    void Moving()
    {
        if (Ship)
        {
            Vector2 direction = Vector2.left;
            if (Vector2.Distance(transform.position, Ship.transform.position) > distance_farthest)
            {
                direction += Vector2.up;
            }
            else if(Vector2.Distance(transform.position, Ship.transform.position)<distance_closest)
            {
                direction += Vector2.down;
            }
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

}
