using UnityEngine;
using System.Collections;

public class Stage2Control : MonoBehaviour {
	const int birdMax = 5, cloudMax = 5;
	public static int birdNum = 0, cloudNum = 0;
	public GameObject bird, cloud;
	bool birdTrigger = true, cloudTrigger = true;
	GameObject temp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(birdNum < birdMax && birdTrigger){
			birdTrigger = false;
			StartCoroutine(genBird());
		}
		if(cloudNum < cloudMax && cloudTrigger){
			cloudTrigger = false;
			StartCoroutine(genCloud());
		}
	}
	IEnumerator genBird(){
		birdNum++;
		if(myRandom.aInt (0, 1) == 0){
			temp = Instantiate(bird, new Vector3(-StaticValues.worldboudary - 1, myRandom.aFloat(0, -15), 1), 
			                   Quaternion.identity) as GameObject;
			temp.SetActive(true);
			temp.GetComponent<BirdBehavior>().direction = 1;
		}
		else{
			temp = Instantiate(bird, new Vector3(StaticValues.worldboudary + 1, myRandom.aFloat(0, -15), 1), 
			                   Quaternion.identity) as GameObject;
			temp.SetActive(true);
			temp.GetComponent<BirdBehavior>().direction = -1;
		}
		temp.GetComponent<BirdBehavior> ().moveSpeed = 3 + myRandom.aFloat (-1f, 1f);
		yield return new WaitForSeconds (3 + myRandom.aFloat(-2f, 2f));
		birdTrigger = true;
	}

	IEnumerator genCloud(){
		cloudNum++;
		temp = Instantiate(cloud, new Vector3(myRandom.aFloat(-8, 8), -11, 1), Quaternion.identity) as GameObject;
		temp.SetActive(true);
		yield return new WaitForSeconds (2 + myRandom.aFloat(-2f, 2f));
		cloudTrigger = true;
	}
}
