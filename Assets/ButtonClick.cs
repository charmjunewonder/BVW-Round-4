using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

	private Vector3 originPosition;
	public GameObject plane;
	public GameObject moviePlane;
	// Use this for initialization
	void Start () {
		originPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z - originPosition.z < 0){
			transform.position = originPosition;
		} else if(transform.position.z - originPosition.z > 1){
			transform.position = originPosition + new Vector3(0, 0, 1);
		} 
	}

	void OnCollisionExit(Collision collision){
		transform.position = originPosition;

	}

	void OnCollisionEnter(Collision collision){
		Debug.Log("play");

		if(collision.gameObject == plane){
			this.renderer.enabled = false;
			Debug.Log("kdfja");
		}
	}

}
