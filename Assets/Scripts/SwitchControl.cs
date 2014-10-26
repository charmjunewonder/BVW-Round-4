using UnityEngine;
using System.Collections;

public class SwitchControl : MonoBehaviour {
	public GameObject LightOn, LightOff;
	public Animator s;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void turnOn(){
		LightOff.SetActive (false);
		LightOn.SetActive (true);
		s.SetBool ("On", true);
	}
}
