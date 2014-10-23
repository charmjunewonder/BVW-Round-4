using UnityEngine;
using System.Collections;

public class ConfidentialControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (wait ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator wait(){
		yield return new WaitForSeconds (5);
		Application.LoadLevel ("GamePlay-StageEmergency");
	}

}
