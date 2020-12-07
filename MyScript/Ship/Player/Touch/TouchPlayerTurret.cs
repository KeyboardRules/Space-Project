using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPlayerTurret : MonoBehaviour
{
    public GameObject weapon_prefab;
    public GameObject[] barrel_hardpoints;
    public float shot_speed = 335;
    public float timeBetweenShoot = 0.1f;
    
    Joystick shoot_joystick;
    Vector2 direction;
    float timeReload;
    bool isShooting;
    private void Start()
    {
        shoot_joystick= FindObjectOfType<TouchControllerManager>().GetComponent<TouchControllerManager>().GetShootController();
        timeReload = timeBetweenShoot;
    }
    void Update()
    {
        Inputs();

        Rotate();
        Shoot();
    }
    void Inputs()
    {
        direction = shoot_joystick.Direction;
        if (direction.x != 0 || direction.y != 0)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }
    void Rotate()
    {
        if (isShooting)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f));
        }
    }
    void Shoot()
    {
        if (isShooting && barrel_hardpoints != null && timeReload >= timeBetweenShoot)
        {
            if (FindObjectOfType<AudioManager>()) FindObjectOfType<AudioManager>().PlaySound("Player Shoot");
            foreach (GameObject barrel in barrel_hardpoints)
            {
                GameObject bullet = Instantiate(weapon_prefab, barrel.transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
                if (transform.parent)
                {
                    bullet.tag = transform.parent.tag;
                }
            }
            timeReload = 0;
        }
        timeReload += Time.deltaTime;
    }
}
