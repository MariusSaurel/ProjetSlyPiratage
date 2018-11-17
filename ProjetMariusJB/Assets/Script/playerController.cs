using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    public GameObject Player;
    public Camera cam;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Vector3 difference = Input.mousePosition - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
    //Gère tout ce qui se passe avant une colision
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        Vector2 mouseposition = Input.mousePosition;

    }
}
