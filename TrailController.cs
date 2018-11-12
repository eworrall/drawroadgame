using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour {
    public Transform car;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(car.position.x, car.position.y + 0.5f, 1);
        transform.position = new Vector3(car.position.x - (((car.eulerAngles.z - 90f) / 45f)) * 0.35f, car.position.y + 0.5f, 1f);
	}
}
