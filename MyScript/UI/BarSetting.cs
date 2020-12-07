using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSetting : MonoBehaviour
{
    public Slider slider;
    public void SetMaxValue(int health,int current_health=0)
    {
        slider.maxValue = health;
        slider.value = current_health;
    }
    public void SetCurrentValue(int health)
    {
        slider.value = health;
    }
}
