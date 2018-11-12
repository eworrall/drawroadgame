using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bestMenu : MonoBehaviour {
    private float hiscore;
    public Text hi;

    // Use this for initialization
    void Start () {
        hiscore = PlayerPrefs.GetFloat("Hiscore", hiscore);
        hi.text = "Best: " + hiscore;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
