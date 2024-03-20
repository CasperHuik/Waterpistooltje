using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithEnvironment : MonoBehaviour
{

    [Header("Interaction Variables")]
    public float damage = 10f; 
    public float range = 100f; 

    [Header("GameObjects")]
    public Camera interactCamera; 

    
    void Update()
    {

        if(Input.GetButtonDown("Fire1")){
            Interact();
        }
        
    }

    void Interact(){
        RaycastHit hit; 
        if (Physics.Raycast(interactCamera.transform.position, interactCamera.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Interactable interactable = hit.transform.GetComponent<Interactable>();
            if(interactable!= null){
                interactable.TakeDamage(damage);
            }
        }
    }
}
