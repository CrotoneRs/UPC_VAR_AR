using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnBecameVisible()
    {
        int numChildren = this.transform.parent.childCount;
        for (int i = 0; i < numChildren; ++i)
        {
            if (this.transform.parent.GetChild(i).gameObject.name != "Label")
            {
                this.transform.parent.GetChild(i).localPosition = new Vector3(0, 1.3f, 0);
            }
        }

    }
}
