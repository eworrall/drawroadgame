using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;
    public float score;
    private float hiscore;
    private int otherscore = 0;
    public float pointspersecond;
    public Boolean scoreisincreasing;
	// Use this for initialization

	void Start () {
        score = 0;
        hiscore = PlayerPrefs.GetFloat("Hiscore", hiscore);
	}
	
	// Update is called once per frame
	void Update () {
        if (scoreisincreasing) {
            score += pointspersecond * Time.deltaTime;
        }
        if (score > hiscore)
        {
            hiscore = Mathf.Round(score);
        }

        scoreText.text = "" + Mathf.Round(score);
        hiScoreText.text = "Best: " + hiscore.ToString();
        PlayerPrefs.SetFloat("Hiscore", hiscore);
        /*score += pointspersecond * Time.deltaTime;
        score = 
        scoreText.text = score.ToString(); */
	}
}
