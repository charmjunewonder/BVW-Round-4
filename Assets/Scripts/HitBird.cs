using UnityEngine;
using System.Collections;

public class HitBird : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c){
		if(c.tag == "Bird"){
			Debug.Log ("HitBird");
			Destroy(c.gameObject);
			Stage2Control.birdNum --;
		}
	}
}
