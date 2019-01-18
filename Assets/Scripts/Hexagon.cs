using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour {

    public Rigidbody2D rb;
    public float timer;
    public Spawner spawner;

	// Use this for initialization
	void Start () {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        rb.rotation = Random.Range(0f, 300f);
        transform.localScale = Vector3.one * 10f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale -= Vector3.one * spawner.shrinkSpeed * Time.deltaTime;

        if(transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
        }
	}
}
