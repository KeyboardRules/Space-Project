using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerRocket : MonoBehaviour
{
    public GameObject weapon_prefab;
    public float shot_speed = 335;
    public int max_rocket = 10;
    public int min_rocket = 0;
    public RocketUI rocketUI;
    public GameObject Laser;

    Joystick rocket_shoot;
    int rocket;
    Vector2 direction;
    bool holding;
    bool fire;
    private void Start()
    {
        rocket_shoot = FindObjectOfType<TouchControllerManager>().GetComponent<TouchControllerManager>().GetRocketController();
        rocket = max_rocket;
        if (rocketUI) rocketUI.setRocket(this.rocket);

    }
    void Update()
    {
        Inputs();

        Rotate();
    }
    void Inputs()
    {
        direction = rocket_shoot.Direction;
        if ((direction.x != 0 || direction.y != 0) && !holding)
        {
            holding = true;
            Laser.SetActive(true);
        }
        if (direction.x == 0 && direction.y == 0 && holding)
        {
            holding = false;
            FireRocket();
            Laser.SetActive(false);
        }
    }
    void Rotate()
    {
        if (holding)
        {
            transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f);
        }
    }
    void FireRocket()
    {
        if (rocket > min_rocket)
        {
            FindObjectOfType<AudioManager>().PlaySound("Rocket Launch");
            GameObject rocket = Instantiate(weapon_prefab, transform.position, transform.rotation);
            rocket.GetComponent<Rigidbody2D>().AddForce(rocket.transform.up * shot_speed);
            if (transform.parent)
            {
                rocket.tag = transform.parent.tag;
            }
            this.rocket--;
            if (rocketUI) rocketUI.setRocket(this.rocket);
        }
        else
        {
            Debug.Log("out of rocket");
        }
    }
    public void AddRocket(int number)
    {
        if (number > 0)
        {
            rocket += number;
            if (rocket > max_rocket)
            {
                rocket = max_rocket;
            }
            if (rocketUI) rocketUI.setRocket(this.rocket);
        }
    }
}
