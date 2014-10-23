using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {
	static bool Emergency = true;
	public float blinktime;
	public Material lightOn, lightOff; 
	bool trigger, red;
	MeshRenderer mesh;
	// Use this for initialization
	void Start () {
		mesh = gameObject.GetComponent<MeshRenderer> ();
		red = true;
		trigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Emergency){
			if(trigger){
				if(!red){
					trigger = false;
					red = true;
					mesh.material = lightOn;
					transform.GetChild(0).gameObject.SetActive(true);
					transform.GetChild(1).gameObject.SetActive(true);
					StartCoroutine(wait ());
				}
				else{
					trigger = false;
					red = false;
					mesh.material = lightOff;
					transform.GetChild(0).gameObject.SetActive(false);
					transform.GetChild(1).gameObject.SetActive(false);
					StartCoroutine(wait ());
				}
			}
		}
	}
	IEnumerator wait(){
		yield return new WaitForSeconds (blinktime);
		trigger = true;
	}
}
