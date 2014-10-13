using UnityEngine;
using System.Collections;

public class FoodControl : MonoBehaviour {
	float foodSpeed;
	// Use this for initialization
	void Start () {
		foodSpeed = Stage0Control.tapeSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, 0, -foodSpeed * Time.deltaTime));
		if(transform.position.z < -30){
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider c){
		if(c.tag == "Hand"){
			Debug.Log ("Hit");
			transform.GetChild(0).gameObject.SetActive(false);
			transform.GetChild(1).gameObject.SetActive(true);
		}
	}
}
