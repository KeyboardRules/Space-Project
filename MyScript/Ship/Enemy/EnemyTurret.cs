using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public GameObject weapon_prefab;
    public GameObject[] barrel_hardpoints;
    public float turrel_rotation_speed = 3f;
    public float shot_speed = 335;
    public float timeBetweenShoot = 0.1f;
    public float shoot_range;
    public bool rotate_turret=true;
    public string shoot_sound;

    GameObject playerShip;
    float timeReload;
    // Start is called before the first frame update
    void Start()
    {
        //playerShip = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerShip)
        {
            playerShip = GameObject.FindGameObjectWithTag("Player");
        }
        if (rotate_turret)
        {
            Rotate();
        }
        if (CheckDistance())
        {
            Shoot();
        }
        timeReload += Time.deltaTime;
    }
    bool CheckDistance()
    {
        if (playerShip)
        {
            if (Vector2.Distance(transform.position, playerShip.transform.position) < shoot_range)
            {
                return true;
            }
        }
        return false;
    }
    void Rotate()
    {
        Vector3 difference;
        if (playerShip)
        {
            difference = playerShip.transform.position - transform.position;
        }
        else
        {
            difference = transform.up;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f, Time.deltaTime * turrel_rotation_speed)));
    }
    void Shoot()
    {
        if (timeReload >= timeBetweenShoot)
        {
            FindObjectOfType<AudioManager>().PlaySound(shoot_sound);
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
    }
}
