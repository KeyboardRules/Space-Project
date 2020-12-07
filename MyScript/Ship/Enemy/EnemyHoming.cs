using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoming : MonoBehaviour
{
    public float ship_speed = 10;
    public float time_tracking = 0.5f;
    public float time_waiting = 3;
    public float ship_rotation=3;

    GameObject playerShip;
    //Rigidbody2D rb;
    float tracking_time;
    float waiting_time;
    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player");
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerShip)
        {
            playerShip = GameObject.FindGameObjectWithTag("Player");
        }
        if (playerShip&&tracking_time<=time_tracking&&waiting_time>=time_waiting)
        {
            Rotate();
            tracking_time += Time.deltaTime;
        }
        if (waiting_time < time_waiting)
        {
            waiting_time += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Moving();
    }
    void Rotate()
    {
        Vector3 difference = playerShip.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f, Time.deltaTime * ship_rotation)));
    }
    void Moving()
    {
        //rb.MovePosition((Vector2)transform.position + Movement *rocket_speed * Time.deltaTime);
        //transform.position = (Vector2)transform.position + Vector2.up * ship_speed * Time.deltaTime;
        transform.Translate(Vector2.up * ship_speed * Time.deltaTime);
    }
    public void ResetTime()
    {
        tracking_time = 0;
        waiting_time = 0;
    }
}
