using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public string theme_name;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayNewTheme(theme_name);
    }
}
