using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    public GameObject player;
    Vector2 boundaries;
    float objectWidth;
    float objectHeight;
    float offsetx;
    float offsety;
    private void Start()
    {
        boundaries = new Vector2(transform.position.x + GetComponent<BoxCollider2D>().size.x/2, transform.position.y + GetComponent<BoxCollider2D>().size.y/2);
        offsetx = GetComponent<BoxCollider2D>().offset.x;
        offsety = GetComponent<BoxCollider2D>().offset.y;
       // Debug.Log(boundaries);
    }
    // Update is called once per frame
    void Update()
    {
        if (player)
        {
          //  player = GameObject.FindGameObjectWithTag("Player");
            objectHeight = player.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            objectWidth = player.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        }
    }
    private void LateUpdate()
    {
        if (player)
        {
            Vector3 position = new Vector3();
            if (offsetx < 0)
            {
                position.x = Mathf.Clamp(player.transform.position.x, -boundaries.x + objectWidth + offsetx, boundaries.x - objectWidth + offsetx);
            }
            else
            {
                position.x = Mathf.Clamp(player.transform.position.x, -boundaries.x + objectWidth - offsetx, boundaries.x - objectWidth - offsetx);
            }
            if (offsety < 0)
            {
                position.y = Mathf.Clamp(player.transform.position.y, -boundaries.y + objectHeight + offsety, boundaries.y - objectHeight + offsety);
            }
            else
            {
                position.y = Mathf.Clamp(player.transform.position.y, -boundaries.y + objectHeight - offsety, boundaries.y - objectHeight - offsety);
            }
            player.transform.localPosition = position;
        }
    }
}
