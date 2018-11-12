using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoadGeneratorController : MonoBehaviour {
    public GameObject theObstacle;
    public Transform generationPoint;
    public float obstacleLocation; //number 1-4 indicating where obstacle is on screen
    public float obstacleLocation2;
    public float distanceBetweenEach;
    private float blockHeight;
    private float spacer = 0.607f;
    private GameObject newOb;
    private GameObject newOb2;
    private float screenwidth;
    public scoreScript score;
    public Movement movement;
    private Vector3 ob2location;
    System.Random rnd = new System.Random();


    void noCloseBlocks()
    {
        if ((obstacleLocation - obstacleLocation2) * .8f == 1.6f)
        {
            obstacleLocation2 = obstacleLocation2 + 1f;
        }
        else if ((obstacleLocation - obstacleLocation2) * .8f == -1.6f)
        {
            obstacleLocation2 = obstacleLocation2 + 1f;
        }
    }

	// Use this for initialization
	void Start () {
        blockHeight = theObstacle.GetComponent<BoxCollider2D>().size.y;
        screenwidth = Screen.width;
        Debug.Log(Screen.width);
        Debug.Log(screenwidth / 5);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < generationPoint.position.y)
        {
            obstacleLocation = rnd.Next(-3, 4); 
            transform.position = new Vector3(obstacleLocation *.8f, transform.position.y + 2 + distanceBetweenEach, transform.position.z);
            newOb = Instantiate(theObstacle, transform.position, transform.rotation);
            newOb.tag = "collideBox";

            if (score.score > 50)
            {
                Debug.Log("passed 25");
                obstacleLocation2 = rnd.Next(-3, 4);
                Debug.Log(obstacleLocation + " and " + obstacleLocation2);
                noCloseBlocks();
                ob2location = new Vector3(obstacleLocation2 * .8f, transform.position.y + 2 + distanceBetweenEach, transform.position.z);
                newOb2 = Instantiate(theObstacle, ob2location, transform.rotation);
                Debug.Log(obstacleLocation + " and " + obstacleLocation2);
                Debug.Log((obstacleLocation * .8f) - (obstacleLocation2 *.8f));
                newOb2.tag = "collideBox";
                if (score.score > 75)
                {
                    //noCloseBlocks();
                    movement.speed = 8f;
                    if (score.score > 150)
                    {
                        movement.speed = 9f;
                        if (score.score > 200)
                        {
                            movement.speed = 10f;
                        }
                    }
                }
                
            } 
        }
	}
}
