using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShieldItem : MonoBehaviour
{
    [SerializeField] Transform super_shield;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("Power Up");
            if (col.GetComponentInChildren<SuperShieldHealth>())
            {
                col.GetComponentInChildren<SuperShieldHealth>().RecoverAll();
            }
            else
            {
                Instantiate(super_shield, col.transform.position, Quaternion.identity).SetParent(col.transform);
            }
            Destroy(this.gameObject);
        }
    }
}
