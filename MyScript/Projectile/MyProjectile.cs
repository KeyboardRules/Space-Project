using UnityEngine;
using System.Collections;
using UnityEditor.UIElements;

public class MyProjectile : MonoBehaviour
{
    public GameObject shoot_effect;
    public GameObject hit_effect;
    public int damage = 1;
    public float exist_time = 3f;
    public bool on_destroy_partical;
    public string collider_sound;

    // Use this for initialization
    void Start()
    {
        //GameObject obj = (GameObject) Instantiate(shoot_effect, transform.position  - new Vector3(0,0,5), Quaternion.identity); //Spawn muzzle flash
        //obj.transform.parent = firing_ship.transform;
        Destroy(gameObject, exist_time); //Bullet will despawn after 5 seconds
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Don't want to collide with the ship that's shooting this thing, nor another projectile.
        if (col.gameObject.tag != this.tag)
        {
            if (!on_destroy_partical)
            {
                FindObjectOfType<AudioManager>().PlaySound(collider_sound);
                Instantiate(hit_effect, transform.position, Quaternion.identity);
            }
            if (col.GetComponent<ShipHealth>()) col.GetComponent<ShipHealth>().DealDamage(damage);
            if (col.GetComponent<ShieldHealth>()) col.GetComponent<ShieldHealth>().DealDamage(damage);
            if (col.GetComponent<SuperShieldHealth>()) col.GetComponent<SuperShieldHealth>().DealDamage(damage);
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        if (on_destroy_partical && CheckProjectileOnCam())
        {
            FindObjectOfType<AudioManager>().PlaySound(collider_sound);
            Instantiate(hit_effect, transform.position, Quaternion.identity);
        }
    }
    private bool CheckProjectileOnCam()
    {
        float distance = Vector2.Distance(Camera.main.transform.position, transform.position);
        Debug.Log(distance);
        if (distance-3 > Camera.main.orthographicSize)
        {
            return false;
        }
        return true;
    }
}

