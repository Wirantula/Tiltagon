using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int score = 0;
    public Controlles controlles;
    public float moveSpeed = 600f;
    float movement = 0f;
    public Spawner spawner;
    public int highScore;
    private UIManager uiManager;

    private void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        controlles = GetComponent<Controlles>();
        HighScore();
    }

    // Update is called once per frame
    void Update () {
        movement = controlles.myInput;
	}

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hexagon"){
            HighScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.tag == "Score"){
            score ++;
        }
    }

    private void HighScore(){
        highScore = PlayerPrefs.GetInt("Highscore", highScore);
        uiManager.UpdateHighScore();
        if (score > highScore){
            highScore = score;
            score = 0;
            uiManager.UpdateHighScore();
            PlayerPrefs.SetInt( "Highscore", highScore);
        }
    }

}
