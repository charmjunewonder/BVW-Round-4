using UnityEngine;
using System.Collections;

public class CubeCollider : MonoBehaviour {

	public bool isTriggered = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		isTriggered = true;
		//Debug.Log("fdsj");
	}
}
