using UnityEngine;
using System.Collections;

public class Stage1Control : MonoBehaviour {
	public GameObject enemyship, myship;
	const int enemyMax = 2;
	int enemyCount = 0;
	bool start;
	GameObject [] eship = new GameObject[enemyMax];
	// Use this for initialization
	void Start () {
		start = true;
		if(start){
			eship [0] = Instantiate (enemyship) as GameObject;
			eship [0].SetActive (true); 

			eship [0].GetComponent<EnemyBehavior> ().moveSpeed = 3;
			eship [0].GetComponent<EnemyBehavior> ().fireTime = 1.5f;
			eship [0].GetComponent<EnemyBehavior> ().chargeTime = 3;
			eship [0].GetComponent<EnemyBehavior> ().sleepTime = 3;

			StartCoroutine (nextShip ());
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator nextShip(){
		yield return new WaitForSeconds (10);
		eship [1] = Instantiate (enemyship) as GameObject;
		eship [1].SetActive (true);

		eship [1].GetComponent<EnemyBehavior> ().moveSpeed = 6;
		eship [1].GetComponent<EnemyBehavior> ().fireTime = 1f;
		eship [1].GetComponent<EnemyBehavior> ().chargeTime = 2;
		eship [1].GetComponent<EnemyBehavior> ().sleepTime = 3;
	}

}
