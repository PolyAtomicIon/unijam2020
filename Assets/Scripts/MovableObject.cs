using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour, MovableInterface
{

    private InteractableObject interaction_script;
    Rigidbody2D rb;
    
    player target;
    float moveSpeed;

    private bool pulling = false;

    public void set_movement_data(player a, float b){
        target = a;
        moveSpeed = b;
    }

    public void Freeze_position(){
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void reFreeze_position(){
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void reset_pushable(){
        interaction_script.pushable = true;
    }

    public void in_range(bool a){
        interaction_script.isInRange = a;
    }

    public bool is_pushable(){
        return interaction_script.pushable;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        interaction_script = GetComponent<InteractableObject>();
       // target = GameObject.FindGameObjectWithTag("Player");

        Freeze_position();
    }

    void Update()
    {
        if( !interaction_script.pushable ){
            Debug.Log(target.name);
            /*
            float angle = target.transform.rotation.z;

            Vector3 direction = new Vector3( Mathf.Cos(angle) * 1.3f, Mathf.Sin(angle) * 1.3f, 0f );
            */
            //Debug.Log(direction);

            // transform.Translate(target.transform.position * Time.deltaTime);
            transform.position = target.pull_pos.position;
        
            pulling = true;
        }

        if( interaction_script.pushable && pulling ){
            pulling = false;
            interaction_script.isInRange = false;
            Freeze_position();
            target.interacting = false;
        }

    }


}
