using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public Transform boy, target;
	public bool controlable;
	public Animator boyAnim;
	const float threshold = 0.3f; 
	// Use this for initialization
	void Start () {
		controlable = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dis = target.position - transform.position;
		dis.z = 0;
		BoyDirection ();
		if(dis.magnitude > threshold){
			boyAnim.SetBool("Walk", true);
			//print (dis.magnitude);
			rigidbody.velocity = Vector3.zero;
			transform.Translate(dis.normalized * speed * Time.deltaTime);
			//target.transform.Translate(-dis.normalized * speed * Time.deltaTime);
		}
		else{
			boyAnim.SetBool("Walk", false);
			rigidbody.velocity = Vector3.zero;
		}
	}
	void BoyDirection(){
		//print (boy.eulerAngles);
		Vector3 dir = target.position - boy.position;
		if(dir.y / Mathf.Abs(dir.x) > 2){
			boy.eulerAngles = new Vector3(0, 0, 0);
		}
		else if(dir.y / Mathf.Abs(dir.x) < -2){
			boy.eulerAngles = new Vector3(0, 180, 0);
		}
		else if(dir.x / Mathf.Abs(dir.y) < -2){
			boy.eulerAngles = new Vector3(0, -90, 0);
		}
		else if(dir.x / Mathf.Abs(dir.y) > 2){
			boy.eulerAngles = new Vector3(0, 90, 0);
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
