using UnityEngine;
using System.Collections;

public class BoyBehavior : MonoBehaviour {
	public float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a")){
			transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
		}
		if(Input.GetKey("d")){
			transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
		}
		if(Input.GetKey("w")){
			transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
		}
		if(Input.GetKey("s")){
			transform.Translate(new Vector3(0, -moveSpeed * Time.deltaTime, 0));
		}

		if(transform.position.x >= StaticValues.worldboudary){
			transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
		}
		if(transform.position.x <= -StaticValues.worldboudary){
			transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
		}
		if(transform.position.y <= -StaticValues.worldboudary){
			transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
		}
		if(transform.position.y >= StaticValues.worldboudary){
			transform.Translate(new Vector3(0, -moveSpeed * Time.deltaTime, 0));
		}
	}
}
