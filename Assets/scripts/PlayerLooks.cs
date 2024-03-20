using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerLooks : NetworkBehaviour
{

    [Header("Player Color")]
    public Material materialP1; 
    public Material materialP2; 
    public Material materialP3; 
    public Material materialP4; 

    [Header("Player Hat")]
    public GameObject networkHat1;
    public GameObject networkHat2;
    public GameObject glasses; 

    [Header("Player GameObjects")]
    [SerializeField] GamePlayer gamePlayerScript; 

    public Renderer rend;


    public void Start(){
        rend.enabled = true; 
        if(gamePlayerScript.playerNumber == 1){

            //color
            rend.sharedMaterial = materialP1;

            //network hat
            if(isLocalPlayer){ 
                networkHat1.SetActive(false);
                glasses.SetActive(false);
                Debug.Log("Hat 1 false");
            }
            else{
                networkHat1.SetActive(true);
                glasses.SetActive(true);
                Debug.Log("Hat 1 true");
            }
            networkHat2.SetActive(false);
        }
        else if(gamePlayerScript.playerNumber == 2){
            //color
            rend.sharedMaterial = materialP2;
            
            //network hat
            if(isLocalPlayer){ 
                networkHat2.SetActive(false);
                glasses.SetActive(false);
            }
            else{
                networkHat2.SetActive(true);
                glasses.SetActive(true);
            }
            networkHat1.SetActive(false);
        }
        else if(gamePlayerScript.playerNumber == 3){
            //color
            rend.sharedMaterial = materialP3; 
            
            //network hat
            if(isLocalPlayer){ 
                networkHat1.SetActive(false);
                glasses.SetActive(false);
            }
            else{
                networkHat1.SetActive(true);
                glasses.SetActive(true);

            }
            networkHat2.SetActive(false);
        }
        else{
            //color
            rend.sharedMaterial = materialP4;

            //network hat
            if(isLocalPlayer){ 
                networkHat2.SetActive(false);
                glasses.SetActive(false);
            }
            else{
                networkHat2.SetActive(true);
                glasses.SetActive(true);

            }
            networkHat1.SetActive(false);
        }
        
    }
}
