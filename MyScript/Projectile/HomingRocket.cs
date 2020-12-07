using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour
{
    public float rocket_speed=3;
    public float rocket_rotation = 3;

    GameObject PlayerShip;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Rotate();
    }
    private void FixedUpdate()
    {
        Moving();
    }
    void Rotate()
    {
        Vector3 difference;
        if (PlayerShip)
        {
            difference = PlayerShip.transform.position - transform.position;
        }
        else
        {
            difference = transform.up;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f, Time.deltaTime * rocket_rotation)));
    }
    void Moving()
    {
        //rb.MovePosition((Vector2)transform.position + Movement *rocket_speed * Time.deltaTime);
        //transform.position = (Vector2)transform.position + Vector2.up * rocket_speed * Time.deltaTime;
        transform.Translate(Vector2.up * rocket_speed * Time.deltaTime);
    }
}
