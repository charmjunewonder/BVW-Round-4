using UnityEngine;
using System.Collections;

public class Blast : MonoBehaviour {
	public float speed, rotatespeed;
	// Use this for initialization
	void Start () {
		for(int i =0;i<9;i++){
			transform.GetChild(i).gameObject.rigidbody.velocity = new Vector3(
				myRandom.aFloat(-speed/2, speed/2), 
				myRandom.aFloat(-speed/2, speed/2),
				0
				);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
