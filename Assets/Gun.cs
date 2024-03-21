using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gun : NetworkBehaviour
{
    public float damage = 0f;
    public Transform player;
    public Transform spawnPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Fire();
        }
    }

    void Fire(){
        
        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
    }
}
