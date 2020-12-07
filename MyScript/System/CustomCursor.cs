using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture cursorTexture;

    public float deadzone_radius = 0f;
    public static Vector2 pointerPosition;

    [HideInInspector]
    public Rect deadzone_rect;
    public static CustomCursor instance;
    void Awake()
    {
        pointerPosition = new Vector2(Screen.width / 2, Screen.height / 2); //Set pointer position to center of screen
        instance = this;
    }
    void Start()
    {
        deadzone_rect = new Rect((Screen.width / 2) - (deadzone_radius), (Screen.height / 2) - (deadzone_radius), deadzone_radius * 2, deadzone_radius * 2);
    }

    // Update is called once per frame
    void Update()
    {
        pointerPosition = Input.mousePosition;
    }
    void OnGUI()
    {
        if (cursorTexture != null && !PauseMenu.is_pause && !GameManger.tran_scene)
        {
            Cursor.visible = false;
            GUI.DrawTexture(new Rect(pointerPosition.x - (cursorTexture.width / 2), Screen.height - pointerPosition.y - (cursorTexture.height / 2), cursorTexture.width, cursorTexture.height), cursorTexture);
        }
            
        else
        {
            Cursor.visible = true;
        }
    }
    
}
