using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShutdown : MonoBehaviour
{
    public float radius_effect;
    public int damage;
    public LayerMask shield;
    public GameObject shield_sockwave;

    ShieldHealth sh;
    bool sockwave;
    bool isSockwave;
    // Start is called before the first frame update
    void Start()
    {
        sh = GetComponent<ShieldHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        ShieldUpdate();
        Shutdown();
    }
    void ShieldUpdate()
    {
        if (sh && sh.isDisable() && !isSockwave)
        {
            sockwave = true;
        }
        else if(sh && !sh.isDisable())
        {
            isSockwave = false;
        }
    }
    void Shutdown()
    {
        if (sockwave)
        {
            Instantiate(shield_sockwave, transform.position, Quaternion.identity);
            Collider2D shipObject= Physics2D.OverlapCircle(transform.position, radius_effect,shield);
            if (shipObject && shipObject.tag=="Player")
            {
                shipObject.GetComponent<ShieldHealth>().DealDamage(damage);
            }
            sockwave = false;
            isSockwave = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius_effect);
    }
}
