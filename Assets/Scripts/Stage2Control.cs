using UnityEngine;
using System.Collections;

public class Stage2Control : MonoBehaviour {
	const int birdMax = 3, cloudMax = 4;
	public static int birdNum = 0, cloudNum = 0;
	public GameObject bird, cloud, enemybird, myship;
	public float animspeed;
	bool birdTrigger = true, cloudTrigger = true, start, init;
	GameObject temp;
	// Use this for initialization
	void Start () {
		start = false;
		init = true;


	}
	
	// Update is called once per frame
	void Update () {
		if (init) {
			myship.GetComponent<BoyBehavior>().useLeapMotion = false;
			temp = Instantiate(enemybird, new Vector3(-StaticValues.worldboudary - 1, 0, -5), 
			                   Quaternion.identity) as GameObject;
			temp.SetActive(true);
			temp.GetComponent<BirdBehavior>().direction = 1;
			temp = Instantiate(cloud, new Vector3(-7, -11, -5), Quaternion.identity) as GameObject;
			temp.SetActive(true);
			init = false;
			StartCoroutine(gamestart());
		}
		if(start){
			if(birdNum < birdMax && birdTrigger){
				birdTrigger = false;
				StartCoroutine(genBird());
			}
			if(cloudNum < cloudMax && cloudTrigger){
				cloudTrigger = false;
				StartCoroutine(genCloud());
			}
		}
	}
	IEnumerator genBird(){
		birdNum++;
		if(myRandom.aInt (0, 1) == 0){
			temp = Instantiate(bird, new Vector3(-StaticValues.worldboudary - 1, myRandom.aFloat(0, -15), -5), 
			                   Quaternion.identity) as GameObject;
			temp.SetActive(true);
			temp.GetComponent<BirdBehavior>().direction = 1;
		}
		else{
			temp = Instantiate(bird, new Vector3(StaticValues.worldboudary + 1, myRandom.aFloat(0, -15), -5), 
			                   Quaternion.identity) as GameObject;
			temp.SetActive(true);
			temp.GetComponent<BirdBehavior>().direction = -1;
		}
		temp.GetComponent<BirdBehavior> ().moveSpeed = 4 + myRandom.aFloat (-2f, 2f);
		yield return new WaitForSeconds (3 + myRandom.aFloat(-2f, 2f));
		birdTrigger = true;
	}

	IEnumerator genCloud(){
		cloudNum++;
		temp = Instantiate(cloud, new Vector3(myRandom.aFloat(-8, 8), -11, -5), Quaternion.identity) as GameObject;
		temp.SetActive(true);
		yield return new WaitForSeconds (2 + myRandom.aFloat(-2f, 2f));
		cloudTrigger = true;
	}
	IEnumerator gamestart(){
		yield return new WaitForSeconds (5);
		myship.GetComponent<BoyBehavior>().useLeapMotion = true;
		start = true;

	}
}
