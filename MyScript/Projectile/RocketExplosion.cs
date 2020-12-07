using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    public float radius_effect;
    public LayerMask ship;
    public GameObject explosion_sockwave;
    public int damage;

    bool explode;
    // Start is called before the first frame update
    void OnDestroy()
    {
        Sockwave();
    }
    void Sockwave()
    {
        if (!explode)
        {
            Instantiate(explosion_sockwave, transform.position, Quaternion.identity);
            Collider2D[] shipObject = Physics2D.OverlapCircleAll(transform.position, radius_effect, ship);
            foreach(Collider2D ship in shipObject)
            {
                if (ship && ship.tag != gameObject.tag)
                {
                    ship.GetComponent<ShipHealth>().DealDamage(damage);

                }
            }
            explode = true;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius_effect);
    }
}
