using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform PlayerRotation;

    private Rigidbody2D rb2d;
    public float speed;
    public GameObject Player;
    public Vector3 mouse_pos;
    public Vector3 object_pos;
    public float angle;
    public bool isLocal;
    private float nextFire;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;


    public void Update()
    {
            mouse_pos = Input.mousePosition;
            object_pos = Camera.main.WorldToScreenPoint(Player.transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 91));
            

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

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        Vector2 mouseposition = Input.mousePosition;

    }
}
