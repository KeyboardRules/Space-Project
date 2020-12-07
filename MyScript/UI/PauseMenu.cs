using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool is_pause=false;
    public GameObject pause_menu_ui;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!is_pause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pause_menu_ui.SetActive(true);
        is_pause = true;
        
    }
    public void Resume()
    {
        is_pause = false;
        Time.timeScale = 1f;
        pause_menu_ui.SetActive(false);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
