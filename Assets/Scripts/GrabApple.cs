using UnityEngine;
using System.Collections;
using Leap;
public class GrabApple : MonoBehaviour {

	public HandController handController;
	public GameObject apple;
	private bool grabSuccessful = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector handPosition = handController.GetComponent<HandController>().getFirstHandPosition();
		//Debug.Log(handPosition*0.001f);
		Vector3 handP = new Vector3(handPosition.x, handPosition.y, 0);
		handP *= 0.001f;
		Vector3 applePosition = new Vector3(transform.position.x, transform.position.y, 0);
		//Debug.Log(Vector2.Distance(handP, applePosition));
		//handController.getHandGrabApple();
		if(Vector3.Distance(handP, applePosition) < 1.53f 
		   && handController.getHandGrabApple()
		   && !grabSuccessful){
			Debug.Log("fjsla");
			grabSuccessful = true;
			StartCoroutine(loadNextLevel());
			//apple.renderer.enabled = true;
		}
//		if(grabSuccessful){ // + 3 - 3.497658f
//			apple.transform.position = new Vector3(handPosition.x * 0.01f, handPosition.y * 0.01f, -handPosition.z * 0.01f - 3.497658f);
//			Debug.Log(apple.transform.position + " " + handPosition * 0.01f);
//		}
		Hand firstHand = handController.GetComponent<HandController>().getFirstHand();
		GameObject hand = null;
		if(firstHand.IsLeft){
			Debug.Log("Left");
			hand = GameObject.Find("CleanRobotLeftHand(Clone)");
		} else if(firstHand.IsRight){
			Debug.Log("Right");
			hand = GameObject.Find("CleanRobotRightHand(Clone)");
		}
//		if(appleClone == null){
//			appleClone = Instantiate(apple) as GameObject;
//			appleClone.transform.localScale = apple.transform.localScale;
//		}
		if(grabSuccessful && hand != null && apple != null){
			Transform palm = hand.transform.FindChild("palm");

			apple.transform.parent = palm;
			//Debug.Log("dsafsdfsdfsad");

			apple.transform.localPosition = new Vector3(0.002436602f, -0.03508028f, 0.01542692f);
		} 
//		else{
//			apple.transform.localPosition = new Vector3(100f, 100f, 100f);
//
//		}

	}

	IEnumerator loadNextLevel(){
		int timerCount = 0;
		while(true){
			timerCount ++;
			if(timerCount > 20 || apple == null){
				Debug.Log("End");
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

    void OnTriggerEnter(Collider other) {
		//Debug.Log("fjsla");
		//if(collider.gameObject.GetComponent<HandController>().getHandGrab()){
		//}
	}
}
