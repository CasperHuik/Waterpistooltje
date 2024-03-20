using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class fpsController : MonoBehaviour
{

    public CharacterController controller; 
    public GameObject PlayerModel; 

    public float speed = 12f;
    public float normalSpeed = 12f; 
    public float sprintSpeed = 24f;  
    public float gravity = -9.81f; 
    public float jumpHeight = 10f; 

    public Transform groundCheck; 
    public float groundDistance = 0.4f; 
    public LayerMask groundMask; 

    Vector3 velocity; 
    bool isGrounded; 

    public float mouseSensitivity = 100f;

    public Transform playerBody; 

    float xRotation = 0f;

    public Camera camera; 


    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f; 
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; 

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(!Input.GetKey(KeyCode.LeftShift)){
            speed = normalSpeed;
        }
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded){
            speed = sprintSpeed;
        }

        velocity.y += gravity * Time.deltaTime; 

        controller.Move(velocity * Time.deltaTime);


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
            
        
    }

  
}

