using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Input.mousePosition;
		pos = Camera.main.ScreenToWorldPoint (pos);
		//print (pos);
		pos.z = -10;
		transform.position = pos;
	
	}
}
