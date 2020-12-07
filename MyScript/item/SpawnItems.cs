using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] Item[] items;
    private void OnDestroy()
    {
        foreach(Item item in items)
        {
            if (UnityEngine.Random.value < 0.25)
            {
                item.Spawn(this.gameObject.transform, Vector2.right * 25);
            }
            else if (UnityEngine.Random.value < 0.25)
            {
                item.Spawn(this.gameObject.transform, Vector2.down * 25);
            }
            else if (UnityEngine.Random.value < 0.25)
            {
                item.Spawn(this.gameObject.transform, Vector2.left * 25);
            }
            else
            {
                item.Spawn(this.gameObject.transform, Vector2.up * 25);
            }
        }
    }

    [Serializable]
    private class Item
    {
        [SerializeField] private GameObject item;
        [SerializeField] [Range(0,1)] private float percent;
        public void Spawn(Transform original,Vector2 force)
        {
            if (UnityEngine.Random.value <= percent)
            {
                GameObject go=Instantiate(item, original.position, Quaternion.identity);
                if (go.GetComponent<Rigidbody2D>()) go.GetComponent<Rigidbody2D>().AddForce(force);

            }
        }
    }
}
