using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 0.5f, 0);
        this.transform.RotateAround(GameObject.Find("Earth").transform.position, Vector3.up, (20f) * Time.deltaTime);
    }
}
