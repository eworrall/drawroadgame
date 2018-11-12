using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour {
    public Transform blackroad;
    public Transform car;
    public float spacer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        blackroad.position = new Vector3 (car.position.x, car.position.y - spacer, 0f);
	}
}
