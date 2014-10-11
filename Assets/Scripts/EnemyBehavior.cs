using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public GameObject laser;
	public float moveSpeed, fireTime, chargeTime, sleepTime;

	bool charge = false, fire = false, sleep = true, move = false;

	float timer = 0, direction = 1;

	// Use this for initialization
	void Start () {
		sleep = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(true){
			if(transform.position.x >= StaticValues.worldboudary){
				direction = -1;
			}
			if(transform.position.x <= -StaticValues.worldboudary){
				direction = 1;
			}
			if(move)
				transform.Translate(new Vector3(direction * moveSpeed * Time.fixedDeltaTime, 0, 0));
			else
				transform.Translate(new Vector3(direction * moveSpeed * Time.fixedDeltaTime / 3, 0, 0));
		}
		if(sleep){
			sleep = false;
			StartCoroutine(weaponSleep());
		}
		if(charge){
			charge = false;
			StartCoroutine(weaponCharge());
		}
		if(fire){
			fire = false;
			StartCoroutine(weaponFire());
		}
	}
	IEnumerator weaponCharge(){
		//Debug.Log ("charge");
		move = false;
		transform.localScale = new Vector3 (2, 2, 2);
		//do sth.
		yield return new WaitForSeconds (chargeTime + myRandom.aFloat(-0.5f,0.5f));
		fire = true;
	}
	IEnumerator weaponFire(){
		//Debug.Log ("fire");
		move = true;
		laser.SetActive (true);
		yield return new WaitForSeconds (fireTime + myRandom.aFloat(-0.5f,0.5f));
		sleep = true;
	}
	IEnumerator weaponSleep(){
		//Debug.Log ("sleep");
		move = true;
		laser.SetActive (false);
		transform.localScale = new Vector3 (1, 1, 1);
		yield return new WaitForSeconds (sleepTime + myRandom.aFloat(-1f,1f));
		charge = true;
	}
}
