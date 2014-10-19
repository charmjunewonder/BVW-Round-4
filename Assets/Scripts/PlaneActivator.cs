using UnityEngine;
using System.Collections;

public class PlaneActivator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activate(){
		gameObject.renderer.enabled = true;
	}

	public void deactivate(){
		gameObject.renderer.enabled = false;
	}
}
