using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    public GameObject[] inventoryItems; 
    public int activeItem = 4; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            activeItem = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            activeItem = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            activeItem = 2;
        }
        Debug.Log(activeItem);
        for(var i = 0; i < inventoryItems.Length; i++){
            if(i == activeItem){
                inventoryItems[i].SetActive(true);
            }
            else{
                inventoryItems[i].SetActive(false);
            }
        }

    }
}
