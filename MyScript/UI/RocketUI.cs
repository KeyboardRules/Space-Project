using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocketUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void setRocket(int rocket)
    {
        text.text = rocket.ToString();
    }
}
