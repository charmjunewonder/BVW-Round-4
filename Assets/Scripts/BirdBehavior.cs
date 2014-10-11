using UnityEngine;
using System.Collections;

public class BirdBehavior : MonoBehaviour {
	public float direction = 0, moveSpeed = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > StaticValues.worldboudary + 2 || 
		   transform.position.x < -StaticValues.worldboudary - 2){
			Debug.Log ("birdDeath");
			Stage2Control.birdNum --;
			Destroy(gameObject);
		}
		transform.Translate(new Vector3(moveSpeed * Time.deltaTime * direction, StaticValues.worldspeed * Time.deltaTime, 0));
	}

	
}
