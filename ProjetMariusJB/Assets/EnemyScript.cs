using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyScript : MonoBehaviour
{

    public string EnemyType;
    public Transform PlayerT;
    public float turnSpeed = 1f;
    public Rigidbody2D rb2d;
    private playerController player;
    private int playerHealth;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }

    void Update()
    {
        if (EnemyType == "Kamikaze")
        {
            LockOnTarget();
            rb2d.velocity = transform.up * 5;
        }

    }

    public void LockOnTarget()
    {
        float angle = Mathf.Atan2(PlayerT.position.y, PlayerT.position.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 91));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.tag == "Player")
        {
            Destroy(this.gameObject);
            player.DamagePlayer(1);
        }
    }
}
