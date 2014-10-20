using UnityEngine;
using System.Collections;

public class PartBehavior : MonoBehaviour {
	public float rotatespeed;
	// Use this for initialization
	void Start () {
		transform.GetChild(myRandom.aInt(0, 3)).gameObject.SetActive(true);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(rotatespeed * myRandom.aFloat(0, 1), rotatespeed * myRandom.aFloat(0, 1), rotatespeed * myRandom.aFloat(0, 1)));
		if(transform.position.x < -StaticValues.worldboudary_x ||
		   transform.position.x > StaticValues.worldboudary_x ||
		   transform.position.y < -StaticValues.worldboudary_y ||
		   transform.position.y > StaticValues.worldboudary_y){
			Destroy(gameObject);
		}
	}
}
