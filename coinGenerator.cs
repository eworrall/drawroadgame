using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGenerator : MonoBehaviour {
    public GameObject coin;
    public Transform coinPoint;
    private float coinLoc;
    System.Random rnd = new System.Random();
    public float distanceBetweenCoinVert;
    private float screenwidth;
    private GameObject newCoin;
    // Use this for initialization
    void Start () {
        screenwidth = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < coinPoint.position.y)
        {
            coinLoc = rnd.Next(-3, 4);
            transform.position = new Vector3(coinLoc * .8f, transform.position.y + 2 + distanceBetweenCoinVert, transform.position.z);
            newCoin = Instantiate(coin, transform.position, transform.rotation);
            newCoin.tag = "coin";
            //make sure to update transform.position
        }
	}
}
