using UnityEngine;
using System.Collections;

public class Stage0Control : MonoBehaviour {
	public static float tapeSpeed = 10;
	public GameObject lefthand, righthand, food;
	GameObject temp;
	bool foodTriggerLeft, foodTriggerRight;
	// Use this for initialization
	void Start () {
		foodTriggerLeft = true;
		foodTriggerRight = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("z")){
			lefthand.GetComponent<Bang>().bangTrigger();
		}
		if(Input.GetKeyDown ("c")){
			righthand.GetComponent<Bang>().bangTrigger();
		}
		if(foodTriggerLeft){
			foodTriggerLeft = false;
			StartCoroutine(genFood(-10));
		}
		if(foodTriggerRight){
			foodTriggerRight = false;
			StartCoroutine(genFood(10));
		}
	}
	IEnumerator genFood(float x){

		temp = Instantiate(food, new Vector3(x, -9.5f, 130), Quaternion.identity) as GameObject;
		temp.SetActive (true);
		temp.transform.GetChild(0).gameObject.SetActive(true);
		yield return new WaitForSeconds (4 + myRandom.aFloat(-2f, 2f));
		if(x < 0)
			foodTriggerLeft = true;
		else
			foodTriggerRight = true;
	}
}
