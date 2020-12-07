using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public GameObject weapon_prefab;
    public GameObject[] barrel_hardpoints;
    public float turrel_rotation_speed = 3f;
    public float shot_speed= 335;
    public float timeBetweenShoot=0.1f;

    float timeReload;
    bool isShooting;
    private void Start()
    {
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
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
        }
        if (!Input.GetButton("Fire1"))
        {
            isShooting = false;
        }
    }
    void Rotate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(CustomCursor.pointerPosition) - transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f, Time.deltaTime * turrel_rotation_speed)));
    }
    void Shoot()
    {
        if (isShooting && barrel_hardpoints != null && timeReload>=timeBetweenShoot)
        {
            if(FindObjectOfType<AudioManager>()) FindObjectOfType<AudioManager>().PlaySound("Player Shoot");
            foreach(GameObject barrel in barrel_hardpoints)
            {
                GameObject bullet = Instantiate(weapon_prefab, barrel.transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
                if(transform.parent)
                {
                    bullet.tag= transform.parent.tag;
                }
            }
            timeReload = 0;
        }
        timeReload += Time.deltaTime;
    }
}
