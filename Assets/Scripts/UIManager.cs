using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Player player;

    private int registeredScore;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        registeredScore = player.score;
        scoreText.text = "SCORE: " + registeredScore;
    }

    public void UpdateHighScore(){
        highScoreText.text = "HIGHSCORE: " + player.highScore;
    }
}
