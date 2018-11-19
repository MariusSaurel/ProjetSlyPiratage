using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float speed = 70f;
    public Transform Player;
    private GameObject Spawnpoint;
    public GameObject Bullet;

    public float explosionRadius = 0f;
    public GameObject impactEffect;
    private Vector3 dir;

    public void Start()
    {
	
    }

    // Update is called once per frame
    void Update()
    {
	   rb2d.velocity = transform.up * speed;
         
        //Debug.Log(rb2d.velocity);
    }

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        Debug.Log(hit.tag);
        if (hit.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (hit.tag == "Bullet")
        {
            Destroy(hit);
            Destroy(this.gameObject);
        }
    }


    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            //Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        
    }
}
