using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{

    public string EnemyType;
    public Rigidbody2D rb2d;
    private GameObject player;
    public int Health;
    public GameObject BulletPrefab;
    private EnemyController EnemyScript;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int ShieldHealth;
    public GameObject Shield;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public float range = 45;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) <= range)
        {
            if (EnemyType == "Kamikaze")
            {
                LockOnTarget();
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
            }
            if (EnemyType == "Tourelle")
            {
                LockOnTarget();
                if (Time.time > nextActionTime)
                {
                    nextActionTime += period;
                    Fire();
                }
            }
            if (EnemyType == "TourelleShield")
            {
                LockOnTarget();
                if (Time.time > nextActionTime)
                {
                    nextActionTime += period;
                    Fire();
                }
            }
            if (EnemyType == "Boss01")
            {
                LockOnTarget();
                if (Time.time > nextActionTime)
                {
                    nextActionTime += period;
                    TireSpecial(1, 5);
                }
            }
        }

        if (Health <= 0)
        {
            GameOverEnemy();
        }
    }

    public void LockOnTarget()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);

        //float angle = Mathf.Atan2(PlayerT.position.y, PlayerT.position.x) * Mathf.Rad2Deg;
        //this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.tag == "Player")
        {
            Destroy(this.gameObject);
            hit.GetComponent<EnemyController>().DamageEnemy(1);
        }
    }

    public void DamageEnemy(int damage)
    {
        if (EnemyType == "TourelleShield")
        {
            if (ShieldHealth <= 0)
            {
                Health -= damage;
            }
            else if (ShieldHealth >= 0)
            {
                ShieldHealth -= damage;
            }
        }
        else
        {
            Health -= damage;
        }
    }

    public void Fire()
    {
        GameObject bulletInstance = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        Vector3 start = bulletInstance.transform.forward;
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), Shield.GetComponent<Collider2D>());
    }

    public void TireSpecial(int TypeTir, int NombreTir)
    {
        if(TypeTir == 1)
        {
            for (int i = 0; i <= NombreTir; i++)
            {
                GameObject bulletInstance = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
                Vector3 start = bulletInstance.transform.forward;
                Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), Shield.GetComponent<Collider2D>());

                GameObject bulletInstance2 = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z - 10,1));
                Vector3 start2 = bulletInstance.transform.forward;
                Physics2D.IgnoreCollision(bulletInstance2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(bulletInstance2.GetComponent<Collider2D>(), Shield.GetComponent<Collider2D>());

                GameObject bulletInstance3 = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 10, 1));
                Vector3 start3 = bulletInstance.transform.forward;
                Physics2D.IgnoreCollision(bulletInstance3.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(bulletInstance3.GetComponent<Collider2D>(), Shield.GetComponent<Collider2D>());
            }
        }
    }

    public void GameOverEnemy()
    {
        Destroy(this.gameObject);
    }
}
