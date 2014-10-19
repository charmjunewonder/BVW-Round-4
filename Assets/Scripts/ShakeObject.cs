using UnityEngine;
using System.Collections;

public class ShakeObject : MonoBehaviour {

	public float shakeOffset = 0.05f;

	public float shakeInterval = 0.1f;

	private int loopCount = 0;
	private Vector3 originalPosition;
	void Start(){
		originalPosition = transform.position;
		shakeObject();

	}
	public void shakeObject(){
		StartCoroutine("DoShakeOject");
	}

	IEnumerator DoShakeOject(){
		while(true){
			transform.position += new Vector3(Random.Range(-shakeOffset, shakeOffset), Random.Range(-shakeOffset, shakeOffset), 0);
			loopCount++;
			if(loopCount > 2){
				transform.position = originalPosition;
				loopCount = 0;
			}
			yield return new WaitForSeconds(shakeInterval);
		}
	}
}
