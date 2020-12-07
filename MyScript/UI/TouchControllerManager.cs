using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllerManager : MonoBehaviour
{
    [SerializeField] Joystick movement_joystick;
    [SerializeField] Joystick shoot_joystick;
    [SerializeField] Joystick rocket_joystick;
    [SerializeField] DashButton dash_button;
    public Joystick GetMovementController()
    {
        return movement_joystick;
    }
    public Joystick GetShootController()
    {
        return shoot_joystick;
    }
    public Joystick GetRocketController()
    {
        return rocket_joystick;
    }
    public DashButton GetDashController()
    {
        return dash_button;
    }
}
