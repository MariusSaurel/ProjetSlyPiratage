using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{

    public string EnemyType;
    public Transform PlayerT;
    public float turnSpeed = 1f;
    public Rigidbody2D rb2d;
    private playerController player;
    private int playerHealth;
    public playerController playerControllerScript;
    public int Health;
    public GameObject BulletPrefab;
    private EnemyController EnemyScript;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }

    void Update()
    {
        if (EnemyType == "Kamikaze")
        {
            LockOnTarget();
            transform.position = Vector2.MoveTowards(transform.position, PlayerT.position, 5 * Time.deltaTime);
        }
        if (EnemyType == "Tourelle")
        {
            LockOnTarget();
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                Fire(1);
            }
        }
        if (Health <= 0)
        {
            GameOverEnemy();
        }
    }

    public void LockOnTarget()
    {
        float angle = Mathf.Atan2(PlayerT.position.y, PlayerT.position.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
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
        Health -= damage;
    }

    public void Fire(int nbtir)
    {
        GameObject bulletInstance = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        Vector3 start = bulletInstance.transform.forward;
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public void GameOverEnemy()
    {
        Destroy(this.gameObject);
    }
}
