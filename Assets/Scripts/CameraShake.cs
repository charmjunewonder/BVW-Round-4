﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	Vector3 originPosition;
	Quaternion originRotation;
	
	float shake_decay;
	float shake_intensity;
	void Start () {
		//Shake ();
	
	}

	IEnumerator shakeCamera(){
		while(shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation =  new Quaternion(
				originRotation.x + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.y + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.z + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.w + Random.Range(-shake_intensity,shake_intensity)*.2f);
			shake_intensity -= shake_decay;
			//yield return new WaitForSeconds(.05f);
			yield return null;
			
		}	
	}

	public void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		shake_intensity = .3f;
		shake_decay = 0.01f;
		StartCoroutine("shakeCamera");

	}


}
