using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed;
    private float nextFire;

    private Rigidbody2D rb2d;
    
    public GameObject Player;
    
    public Transform shotSpawn;
    public float fireRate;
    public int health;
    private Player player = new Player();

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    void Start()
    {
        Health = 10;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
            Vector3 mouse_pos = Input.mousePosition;
            Vector3 object_pos = Camera.main.WorldToScreenPoint(Player.transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 91));
        if (Health <= 0)
        {
            GameOver();
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    public void Fire()
    {
        GameObject bulletInstance = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        Vector3 start = bulletInstance.transform.forward;
        Debug.Log(start);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = start;
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        
    }

    
	
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        Vector2 mouseposition = Input.mousePosition;

    }

    public void DamagePlayer(int damage)
    {
        health -= damage;
    }

    public void GameOver()
    {
        Destroy(this.gameObject);
    }
}
