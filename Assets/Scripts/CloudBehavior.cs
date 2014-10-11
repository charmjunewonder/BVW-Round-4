using UnityEngine;
using System.Collections;

public class CloudBehavior : MonoBehaviour {
	public float direction, moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > StaticValues.worldboudary + 1){
			Stage2Control.cloudNum --;
			Destroy(gameObject);
		}
		transform.Translate(new Vector3(0, StaticValues.worldspeed * Time.deltaTime, 0));
	}

}
