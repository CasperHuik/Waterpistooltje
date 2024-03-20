using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.Audio; 

public class AudioManager : MonoBehaviour
{

    public AudioClip chirpingBirds; 
    public AudioClip lobbyMusic; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name; 
        if(sceneName == "Game"){

        }
    }
}
