using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlles : MonoBehaviour {

    public float myInput;

    private void Start()
    {
        
    }

    private void Update()
    {
#if UNITY_STANDALONE_WIN
        myInput = Input.GetAxisRaw("Horizontal");
#endif
#if UNITY_ANDROID
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (Input.acceleration.x > 0.3 || Input.acceleration.x <-0.3){
            myInput = Mathf.RoundToInt(Input.acceleration.x);
        } else {        myInput = Input.acceleration.x;}

#endif
    }
}
