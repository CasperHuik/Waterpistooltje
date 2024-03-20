using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FpsCounter : MonoBehaviour
{

    public Text fpsCounter; 
    public float fps = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fps = Mathf.Round(1/Time.deltaTime); 
        fpsCounter.text = fps + "fps";
    }
}
