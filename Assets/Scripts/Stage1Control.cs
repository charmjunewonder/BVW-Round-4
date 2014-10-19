using UnityEngine;
using System.Collections;

public class Stage1Control : MonoBehaviour {
	public GameObject enemyship, myship;
	public float animspeed;
	const int enemyMax = 2;
	int enemyCount = 0;
	bool start, init;
	GameObject [] eship = new GameObject[enemyMax];
	// Use this for initialization
	void Start () {
		init = true;
		start = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (init) {
			myship.GetComponent<BoyBehavior>().useLeapMotion = false;
			myship.transform.Translate(new Vector3(0, -animspeed * Time.deltaTime, 0));
			if(myship.transform.position.y <= 0){
				init = false;
				start = true;
				myship.GetComponent<BoyBehavior>().useLeapMotion = true;
			}                    
		}
		if(start){
			start = false;
			StartCoroutine(firstShip());
		}

	}
	IEnumerator firstShip(){
		eship [0] = Instantiate (enemyship) as GameObject;
		eship [0].SetActive (true); 
		
		eship [0].GetComponent<EnemyBehavior> ().moveSpeed = 4;
		eship [0].GetComponent<EnemyBehavior> ().fireTime = 1.5f;
		eship [0].GetComponent<EnemyBehavior> ().chargeTime = 2;
		eship [0].GetComponent<EnemyBehavior> ().sleepTime = 2;

		eship [0].GetComponent<Floating> ().speed = 0.3f;
		eship [0].GetComponent<Floating> ().last = 1f;

		StartCoroutine (nextShip ());
		yield return null;
	}
	IEnumerator nextShip(){
		yield return new WaitForSeconds (10);
		eship [1] = Instantiate (enemyship, new Vector3(10, 7, -5), Quaternion.identity) as GameObject;
		eship [1].SetActive (true);

		eship [1].GetComponent<EnemyBehavior> ().moveSpeed = 6;
		eship [1].GetComponent<EnemyBehavior> ().fireTime = 1f;
		eship [1].GetComponent<EnemyBehavior> ().chargeTime = 1;
		eship [1].GetComponent<EnemyBehavior> ().sleepTime = 1.5f;

		eship [1].GetComponent<Floating> ().speed = 0.4f;
		eship [1].GetComponent<Floating> ().last = 0.8f;

		yield return null;
	}

}
