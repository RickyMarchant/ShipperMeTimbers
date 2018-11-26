using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour {
    public Text scoreText;
    
    // Use this for initialization
    void Start () {
        setScoreText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void setScoreText()
    {
        scoreText.text = "Score " + PlayerMovement.playerScore.ToString();
    }
}
