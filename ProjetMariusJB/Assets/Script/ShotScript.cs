using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float speed = 70f;
    public Transform Player;
    private GameObject Spawnpoint;

    public float explosionRadius = 0f;
    public GameObject impactEffect;
    private Vector3 dir;

    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            
        Debug.Log(rb2d.velocity);
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
