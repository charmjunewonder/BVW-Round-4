using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public Transform target;

	const float threshold = 0.3f; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dis = target.position - transform.position;
		dis.z = 0;
		if(dis.magnitude > threshold){
			//print (dis.magnitude);
			rigidbody.velocity = Vector3.zero;
			transform.Translate(dis.normalized * speed * Time.deltaTime);
			//target.transform.Translate(-dis.normalized * speed * Time.deltaTime);
		}
		else{
			rigidbody.velocity = Vector3.zero;
		}
	}
//	void OnCollisionEnter(Collision c){
//		if(c.gameObject.tag == "Wall"){
//			speed = -1;
//		}
//	}
//	void OnCollisionExit(Collision c){
//		if(c.gameObject.tag == "Wall"){
//			speed = 1;
//		}
//	}

}
