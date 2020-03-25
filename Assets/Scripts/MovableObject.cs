using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    Rigidbody2D rb;

    private boolean pushable;

    void Freeze_position(){
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    void reFreeze_position(){
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pushable = false;
        
        Freeze_position();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision enter " + collision.gameObject.tag );
        if( collision.gameObject.tag == "Player"){
            if( !pushable ){
                reFreeze_position();
            }   
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("collision exit " + collision.gameObject.tag );
        if( collision.gameObject.tag == "Player" && !pushable  ){
            Freeze_position();
        }
    }

}
