using UnityEngine;
using System.Collections;

public class EnemyBirdBehavior : MonoBehaviour {
	public GameObject target;
	public float direction, moveSpeed = 0;
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
		transform.localScale = new Vector3 (-direction, 1, 1);
		if(target.transform.position.x > transform.position.x){
			direction = 1;
		}
		else{
			direction = -1;
		}
		//transform.Translate(new Vector3(moveSpeed * Time.deltaTime * direction, StaticValues.worldspeed * Time.deltaTime, 0));
		//transform.LookAt (target.transform.position);
		float x = target.transform.position.x - transform.position.x;
		float y = target.transform.position.y - transform.position.y;
		Vector3 dis = new Vector3 (x, y, 0);
		//print (dis.normalized);
		transform.Translate (dis.normalized * moveSpeed * Time.deltaTime);
	}
}
