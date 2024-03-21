using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float startVelocity = 0f; 
    float velocity = 0f;
    public float gravity = 9.8f;
    public Collider collider;
    public Transform playerTranform;
    

    // Start is called before the first frame update
    void Start()
    {
        velocity = startVelocity;
    }

    // Update is called once per frame
    void Update()
    {  
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        transform.Translate(Vector3.down * gravity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Ground")){
            Destroy(gameObject);
        }
    }
}
