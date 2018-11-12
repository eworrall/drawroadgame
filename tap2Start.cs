using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tap2Start : MonoBehaviour {

    public string gameLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            //detected screen touch
            SceneManager.LoadScene(gameLevel);
            Time.timeScale = 1f;
        }
	}
}
