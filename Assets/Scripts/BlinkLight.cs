using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour {
	public Material on, off;
	public float blinktime;
	bool trigger, red;
	MeshRenderer mesh;
	// Use this for initialization
	void Start () {
		mesh = gameObject.GetComponent<MeshRenderer> ();
		red = false;
		trigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(trigger){
			if(!red){
				trigger = false;
				red = true;
				mesh.material = on;
				StartCoroutine(wait ());
			}
			else{
				trigger = false;
				red = false;
				mesh.material = off;
				StartCoroutine(wait ());
			}
		}
	}
	IEnumerator wait(){
		yield return new WaitForSeconds (blinktime);
		trigger = true;
	}
}
