using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float acceleration_speed = 1f;
    public float dashing_speed = 2f;
    public int dash_fuel = 300;
    public float fuel_recover_delay = 0.5f;
    public BarSetting bar;
    Joystick movement_joystick;
    DashButton dash_button;

    float xAxis;
    float yAxis;

    bool is_dashing;
    bool recover_fuel;
    float recover_countdown;
    int current_fuel;
    // Start is called before the first frame update
    void Start()
    {
        movement_joystick= FindObjectOfType<TouchControllerManager>().GetComponent<TouchControllerManager>().GetMovementController();
        dash_button= FindObjectOfType<TouchControllerManager>().GetComponent<TouchControllerManager>().GetDashController();
        current_fuel = dash_fuel;
        if (bar) bar.SetMaxValue(dash_fuel, current_fuel);
        if (!rb)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();

        Moving(xAxis, yAxis);
        RecoverFuel();
    }
    void Inputs()
    {
        xAxis = movement_joystick.Horizontal;
        yAxis = movement_joystick.Vertical;

        if (dash_button.isHolding && current_fuel > 0 && !is_dashing)
        {
            Debug.Log("dash");
            if (FindObjectOfType<AudioManager>())
            {
                Debug.Log("find");
                FindObjectOfType<AudioManager>().PlaySound("Ship Engine");
            }
            is_dashing = true;
        }
        else if ((!dash_button.isHolding || current_fuel <= 0) && is_dashing)
        {
            Debug.Log("stop dash");
            if(FindObjectOfType<AudioManager>()) FindObjectOfType<AudioManager>().StopSound("Ship Engine");
            is_dashing = false;
        }
    }
    void Moving(float xAxis, float yAxis)
    {
        float rawInput=0;

        if (xAxis != 0 || yAxis != 0)
        {
            rawInput = 1;
        }
        if (is_dashing)
        {
            rb.velocity = transform.up * dashing_speed;
            current_fuel--;
            if (bar) bar.SetCurrentValue(current_fuel);
        }
        else 
        {
            rb.velocity = transform.up * acceleration_speed * rawInput;
        }
        if (rawInput==1)
        {
            transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(yAxis, xAxis) * Mathf.Rad2Deg) - 90f);
        }
        //rb.AddTorque(xAxis * -rotation_speed * Time.deltaTime);
    }
    void RecoverFuel()
    {
        if (is_dashing)
        {
            recover_fuel = false;
        }
        else if (!recover_fuel)
        {
            if (recover_countdown < fuel_recover_delay)
            {
                recover_countdown += Time.deltaTime;
            }
            else
            {
                recover_fuel = true;
                recover_countdown = 0;
            }
        }
        if (current_fuel < dash_fuel && recover_fuel)
        {
            current_fuel++;
            if (bar) bar.SetCurrentValue(current_fuel);
        }
    }
}
