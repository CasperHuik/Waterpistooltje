using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using Mirror;

public class MouseLook : NetworkBehaviour
{
    [Header("Mouse Sensitivity")]
    public float mouseSensitivity = 100f;

    [Header("GameObjects")]
    public Transform playerBody; 

    float xRotation = 0f;

    public Camera camera; 

    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer){
            camera.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name; 
        if((sceneName == "Game" || sceneName == "map test") && isLocalPlayer){
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY; 
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }
        else{
            Cursor.lockState = CursorLockMode.None;
        }

        
        
    }
}
