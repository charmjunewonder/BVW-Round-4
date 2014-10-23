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
	
	}

	void OnCollisionExit(Collision collision){
		if(collision.gameObject == plane){

		}
	}

}
