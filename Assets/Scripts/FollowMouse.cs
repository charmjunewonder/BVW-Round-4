using UnityEngine;
using System.Collections;
using Leap;
public class FollowMouse : MonoBehaviour {
	public float z;
	public HandController handController;
	public bool useLeapMotion = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(useLeapMotion){
			Vector pos = handController.getFirstHandPosition();
			//Debug.Log (pos);

			transform.localPosition = new Vector3(pos.x * 0.05f, pos.y * 0.04f - 5, z);

		} else{
			Vector3 pos = Input.mousePosition;
			pos = Camera.main.ScreenToWorldPoint (pos);
			//print (pos);
			pos.z = z;
			transform.position = pos;

		}

	
	}
}
