using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector3 current_velocity_vector;
    Vector2 mousePos;

    void Start()
    {
        
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate(){
                
        Vector2 direction = (movement.x * -transform.up + movement.y * transform.right).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2( lookDir.y, lookDir.x ) * Mathf.Rad2Deg;
        rb.rotation = angle;

       // rb.MovePosition(rb.position + (Vector2) transform.forward * moveSpeed * Time.deltaTime);

    }

}
