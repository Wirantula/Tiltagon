using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    private float rotateSpeed = -50f;

	// Use this for initialization
	void Start () {
        StartCoroutine(CameraBump());
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
	}

    IEnumerator CameraBump()
    {   while(true)
        {
            Camera.main.orthographicSize -= 0.3f;
            yield return new WaitForSeconds(0.45f);
            Camera.main.orthographicSize += 0.3f;
            yield return new WaitForSeconds(0.45f);
        }
    }
}
