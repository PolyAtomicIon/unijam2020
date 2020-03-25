using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour, MovableInterface
{

    private InteractableObject interaction_script;
    Rigidbody2D rb;
    
    GameObject target;
        float moveSpeed;

    public void set_movement_data(float b){
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
        target = GameObject.FindGameObjectWithTag("Player");

        Freeze_position();
    }

    void Update()
    {
        if( !interaction_script.pushable ){
            Debug.Log(target.name);
            // transform.Translate(target.transform.position * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target.transform.position + new Vector3(1.5f, 1.5f, 0), Time.time);
        }
    }


}
