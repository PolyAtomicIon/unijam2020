using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float min_speed = 1.3f;
    public float max_speed = 4f;

    public float moveSpeed = 4f;

    public Rigidbody2D rb;
    public Camera cam;

    public Transform pull_pos;

    Vector2 movement;
    Vector3 current_velocity_vector;
    Vector2 mousePos;

    public bool interacting = false;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if( interacting ){
            moveSpeed = min_speed;
        }
        else{
            moveSpeed = max_speed;
        }

        // movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if( movement.magnitude != 0 ){  
        }


    }

    void FixedUpdate(){
                
        //Vector2 direction = (movement.y * transform.right).normalized;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2( lookDir.y, lookDir.x ) * Mathf.Rad2Deg;
        rb.rotation = angle;

    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision enter " + collision.gameObject.tag );
        if( collision.gameObject.tag == "interactable"){
            MovableInterface obj = collision.gameObject.GetComponent<MovableInterface>();
            interacting = true;
            obj.in_range(true);
            obj.reFreeze_position();
            obj.set_movement_data(this, moveSpeed);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("collision exit " + collision.gameObject.tag );
        if( collision.gameObject.tag == "interactable" ){
            MovableInterface obj = collision.gameObject.GetComponent<MovableInterface>();
            if( obj.is_pushable() ){
                obj.in_range(false);
                obj.Freeze_position();
                obj.reset_pushable();
                interacting = false;
            }
        }
    }

}
