using UnityEngine;
using System.Collections;

public class PartBehavior : MonoBehaviour {
	public float rotatespeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, rotatespeed));
		if(transform.position.x < -StaticValues.worldboudary ||
		   transform.position.x > StaticValues.worldboudary ||
		   transform.position.y < -StaticValues.worldboudary ||
		   transform.position.y > StaticValues.worldboudary){
			Destroy(gameObject);
		}
	}
}
