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
        this.transform.RotateAround(this.transform.parent.transform.position, this.transform.parent.transform.TransformVector(new Vector3(0,1,0)), (0.5f/30) * Time.deltaTime);
    }
}
