using UnityEngine;
using System.Collections;

public class GrabApple : MonoBehaviour {

	GameObject hand;
	public HandController handController;
	public GameObject apple;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(hand.transform.position, transform.position) < 3
			&& handController.getHandGrab()){
				apple.renderer.enabled = true;
				apple.transform.parent = hand.transform;
				apple.transform.localPosition = new Vector3(0, 0, 0);
		}
	}

    void OnTriggerEnter(Collider other) {
		Debug.Log("fjsla");
		//if(collider.gameObject.GetComponent<HandController>().getHandGrab()){
		//}
	}
}
