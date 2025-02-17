﻿using UnityEngine;
using System.Collections;

public class BoyEmit : MonoBehaviour {
	public GameObject part;
	public float firespeed;
	public bool useLeapMotion;
	public HandController handController;

	bool cooldown;
	GameObject temp;
	// Use this for initialization
	void Start () {
		cooldown = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x") && cooldown){
			cooldown = false;
			emit();
		}

		if(useLeapMotion && handController.getHandGrab() && cooldown){
			cooldown = false;
			emit();
		}
	
	}
	void emit(){
		audio.Play ();
		temp = Instantiate (part, transform.position, Quaternion.identity) as GameObject;  
		temp.SetActive (true);
		temp.transform.rigidbody.velocity = new Vector3 (-firespeed / 1.414f, -firespeed / 1.414f, 0);
		
		temp = Instantiate (part, transform.position, Quaternion.identity) as GameObject;
		temp.SetActive (true);
		temp.transform.rigidbody.velocity = new Vector3 (0, -firespeed, 0);
		
		temp = Instantiate (part, transform.position, Quaternion.identity) as GameObject;  
		temp.SetActive (true);
		temp.transform.rigidbody.velocity = new Vector3 (firespeed / 1.414f, -firespeed / 1.414f, 0);
		
//		temp = Instantiate (part, transform.position, Quaternion.identity) as GameObject;  
//		temp.SetActive (true);
//		temp.transform.rigidbody.velocity = new Vector3 (-firespeed / 1.414f, firespeed / 1.414f, 0);
//		
//		temp = Instantiate (part, transform.position, Quaternion.identity) as GameObject;
//		temp.SetActive (true);
//		temp.transform.rigidbody.velocity = new Vector3 (0, firespeed, 0);
//		
//		temp = Instantiate (part, transform.position, Quaternion.identity) as GameObject;  
//		temp.SetActive (true);
//		temp.transform.rigidbody.velocity = new Vector3 (firespeed / 1.414f, firespeed / 1.414f, 0);
		StartCoroutine (cooling ());
	}
	IEnumerator cooling(){
		yield return new WaitForSeconds(1.5f);
		cooldown = true;
	}
}
