using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : MonoBehaviour
{
    public GameObject weapon_prefab;
    public float shot_speed = 335;
    public int max_rocket = 10;
    public int min_rocket = 0;
    public RocketUI rocketUI;

    int rocket;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        rocket = max_rocket ;
        if (rocketUI) rocketUI.setRocket(this.rocket);
    }
    void Update()
    {
        Rotate();
        FireRocket();
    }
    void Rotate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(CustomCursor.pointerPosition) - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f);
    }
    void FireRocket()
    {
        if (Input.GetButtonDown("Fire2"))
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
