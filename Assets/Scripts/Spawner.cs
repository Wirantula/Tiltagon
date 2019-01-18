using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float spawnRate = 1f;
    public GameObject hexagonPrefab;
    public GameObject triPlatePrefab;
    public float shrinkSpeed;
    private int amountOfTris = 1;
    private float nextSpawnTime = 0f;
    public Player player;

    void Start(){
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update () {
		if( Time.time >= nextSpawnTime && amountOfTris%6 == 0)
        {
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity, transform);
            nextSpawnTime = Time.time + 1f / spawnRate;
            amountOfTris = 1;
        } else if ( Time.time >= nextSpawnTime)
        {
            Instantiate(triPlatePrefab, Vector3.zero, Quaternion.identity, transform);
            nextSpawnTime = Time.time + 1f / spawnRate;
            amountOfTris++;
        }

        if (player.score % 9 == 0 && player.score > 1)
        {
            StartCoroutine(SpeedBoost());
        }
    }

    IEnumerator SpeedBoost()
    {
        Camera.main.backgroundColor = Color.white;
        shrinkSpeed = 4f;
        yield return new WaitForSeconds(3);
        shrinkSpeed = 2f;
        Camera.main.backgroundColor = Color.black;
    }
}
