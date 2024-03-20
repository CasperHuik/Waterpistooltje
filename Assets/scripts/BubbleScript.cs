using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    public GameObject[] objectsToSetFalse; 
    public GameObject[] objectsToSetTrue; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        for(int i = 0; i < objectsToSetFalse.Length; i++){
            objectsToSetFalse[i].SetActive(false);
        }
        for(int i = 0; i < objectsToSetTrue.Length; i++){
            objectsToSetTrue[i].SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other){
        for(int i = 0; i < objectsToSetFalse.Length; i++){
            objectsToSetFalse[i].SetActive(true);
        }
        for(int i = 0; i < objectsToSetTrue.Length; i++){
            objectsToSetTrue[i].SetActive(false);
        }
    }
}
