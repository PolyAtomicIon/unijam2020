using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    
    public bool pushable;

    public void pull_object(){
        pushable = (pushable ^ true);
    }

    void Start()
    {
        pushable = true;
    }

    void Update()
    {
        
        //interaction
        if(isInRange){
            if( Input.GetKeyDown(interactKey) ){
                interactAction.Invoke();
            }
        }

    }
}
