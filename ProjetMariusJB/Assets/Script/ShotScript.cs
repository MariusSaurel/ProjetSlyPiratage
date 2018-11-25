using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 70f;
    public GameObject Player;
    private GameObject Spawnpoint;
    public GameObject Bullet;

    public float explosionRadius = 0f;
    public GameObject impactEffect;
    private Vector3 dir;
    public playerController PlayerScript;

    public void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
        Player = GameObject.FindGameObjectWithTag("Player");

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
        if (hit.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (hit.tag == "Bullet")
        {
            Destroy(hit);
            Destroy(this.gameObject);
        }
        if (hit.tag == "Player")
        {
            hit.GetComponent<playerController>().DamagePlayer(1);
        }
        if (hit.tag == "Enemy")
        {
            Destroy(this.gameObject);
            hit.GetComponent<EnemyController>().DamageEnemy(1);
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
