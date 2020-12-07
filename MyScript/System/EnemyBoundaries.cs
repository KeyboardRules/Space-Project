using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBoundaries : MonoBehaviour
{
    public Transform[] ResetPoint;

    Vector2 boundaries;
    // Start is called before the first frame update
    void Start()
    {
        boundaries = new Vector2(transform.position.x + GetComponent<BoxCollider2D>().offset.x + GetComponent<BoxCollider2D>().size.x / 2, transform.position.y + GetComponent<BoxCollider2D>().offset.y + GetComponent<BoxCollider2D>().size.y / 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            if (CheckOut(col.transform))
            {
                System.Random rd = new System.Random();
                int index = rd.Next(ResetPoint.Length);
                col.transform.position = ResetPoint[index].position;
                col.transform.rotation = ResetPoint[index].rotation;
                if (col.GetComponent<EnemyHoming>()) col.GetComponent<EnemyHoming>().ResetTime();
                if (col.GetComponent<EnemyTracking>()) col.GetComponent<EnemyTracking>().ResetTracking();
            }
        }
    }
    bool CheckOut(Transform Enemy)
    {
        float objectHeight = Enemy.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float objectWidth = Enemy.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        if (Enemy.position.x < -boundaries.x + objectWidth|| Enemy.position.x > boundaries.x - objectWidth || Enemy.position.y < -boundaries.y + objectHeight || Enemy.position.y > boundaries.y - objectHeight)
        {
            return true;
        }
        return false;
    }
}
