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
		   && handController.getHandGrabApple()){
			Debug.Log("fjsla");
			grabSuccessful = true;
			//apple.renderer.enabled = true;
		}
		if(grabSuccessful)
			apple.transform.position = new Vector3(handPosition.x * 0.001f, handPosition.y * 0.001f, handPosition.z * 0.001f - 3.497658f);

	}

    void OnTriggerEnter(Collider other) {
		//Debug.Log("fjsla");
		//if(collider.gameObject.GetComponent<HandController>().getHandGrab()){
		//}
	}
}
