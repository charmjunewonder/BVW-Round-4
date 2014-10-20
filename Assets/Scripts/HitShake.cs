using UnityEngine;
using System.Collections;

public class HitShake : MonoBehaviour {
	public AlertControl AlertScreen;
	public CameraShake cameraShake;
	bool start = false, finished = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(start && finished){
			start = false;
			finished = false;
			//StartCoroutine(shakeCamera());
			AlertScreen.fadeStart ();
			cameraShake.Shake();
			StartCoroutine(cooldown());
		}
		else if(finished){
			start = false;
		}
	}
	public void hit(){
		start = true;
	}
	IEnumerator cooldown(){
		yield return new WaitForSeconds(1);
		finished = true;
	}

}
