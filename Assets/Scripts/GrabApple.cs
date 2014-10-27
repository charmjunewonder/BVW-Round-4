using UnityEngine;
using System.Collections;
using Leap;
public class GrabApple : MonoBehaviour {
	public GameObject boy;
	public HandController handController;
	public GameObject apple;
	public GameObject background;
	public GameObject backgroundPlane;
	public Texture[] backgrounds;
	private bool grabSuccessful = false;
	private bool startToGrab = false;
	// Use this for initialization
	void Start () {
		background.transform.localScale = new Vector3(1, 1, 1);
		backgroundPlane.renderer.material.mainTexture = backgrounds[0];
		StartCoroutine(scaleImage());
		handController.hideHands = true;
	}

	IEnumerator scaleImage(){
		yield return new WaitForSeconds(2.0f);

		for(int i = 0; i < 20; i++){
			background.transform.localScale += new Vector3(0.1f, 0.1f, 0f);
			yield return new WaitForSeconds(0.03f);

		}
		boy.SetActive(false);
		startToGrab = true;
		handController.hideHands = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(!startToGrab || handController == null)
			return;
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
			backgroundPlane.renderer.material.mainTexture = backgrounds[1];

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
	IEnumerator scaleImageBack(){
		yield return new WaitForSeconds(3f);

		handController.hideHands = true;
		GameObject rightHandG = GameObject.Find("CleanRobotRightHand(Clone)");
		if(rightHandG != null){
			Destroy(rightHandG);
		}
		GameObject leftHandG = GameObject.Find("CleanRobotLeftHand(Clone)");
		if(leftHandG != null){
			Destroy(leftHandG);
		}	

		for(int i = 0; i < 20; i++){
			background.transform.localScale -= new Vector3(0.1f, 0.1f, 0f);
			yield return new WaitForSeconds(0.03f);
			
		}
		boy.SetActive(true);
		boy.GetComponent<GrabAppleBoy>().back = true;


	}
	IEnumerator loadNextLevel(){
		StartCoroutine(scaleImageBack());
		yield return new WaitForSeconds(7);
		int timerCount = 0;
		while(true){
			timerCount ++;
			if(timerCount > 20 || apple == null){
				Debug.Log("End");
				Application.LoadLevel("Ends");
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

}
