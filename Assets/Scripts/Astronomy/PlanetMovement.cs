using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;

public class PlanetMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    
    public void Update()
    {
        this.transform.Rotate(0, 0.5f, 0);
        StateManager vuforiaStateManager = TrackerManager.Instance.GetStateManager();
        List<TrackableBehaviour> activeTrackables = vuforiaStateManager.GetActiveTrackableBehaviours().ToList();
        foreach (TrackableBehaviour tr in activeTrackables)
        {
                
            if (tr.TrackableName.Equals("QR_CODE_PHOSPHORUS_1") && !this.gameObject.name.Equals("Sun") && this.gameObject.GetComponent<Renderer>().isVisible){
                Debug.Log(tr.TrackableName + "TROVATO");
                
                this.transform.RotateAround(GameObject.Find("Sun").transform.position, GameObject.Find("Sun").transform.parent.transform.TransformVector(Vector3.up), (20f) * Time.deltaTime);
            }
        }
    }

    

    public void OnBecameInvisible()
    {
        if (this.name.Equals("Sun"))
        {
            GameObject earth = GameObject.Find("Earth");
            earth.transform.localPosition = new Vector3(0, 1.3f, 0);

            GameObject mars = GameObject.Find("Mars");
            mars.transform.localPosition = new Vector3(0, 1.3f, 0);

            GameObject venus = GameObject.Find("Venus");
            venus.transform.localPosition = new Vector3(0, 1.3f, 0);

            GameObject mercury = GameObject.Find("Mercury");
            mercury.transform.localPosition = new Vector3(0, 1.3f, 0);

            GameObject jupiter = GameObject.Find("Jupiter");
            jupiter.transform.localPosition = new Vector3(0, 1.3f, 0);

            GameObject Saturn = GameObject.Find("Saturn");
            Saturn.transform.localPosition = new Vector3(0, 1.3f, 0);

            GameObject Uranus = GameObject.Find("Uranus");
            Uranus.transform.localPosition = new Vector3(0, 1.3f, 0);

            GameObject Neptune = GameObject.Find("Neptune");
            Neptune.transform.localPosition = new Vector3(0, 1.3f, 0);

            GameObject Pluto = GameObject.Find("Pluto");
            Pluto.transform.localPosition = new Vector3(0, 1.3f, 0);
        }
    }
}
