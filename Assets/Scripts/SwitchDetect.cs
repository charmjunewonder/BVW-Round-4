using UnityEngine;
using System.Collections;

public class SwitchDetect : MonoBehaviour {
	public HandAnimation hand;
	public SwitchControl on;
	public TurnOntheLight light;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c){
		if(c.tag == "Switch"||c.tag == "Light"){
			hand.anim = true;
		}
	}
	void OnTriggerStay(Collider c){
		if(c.tag == "Switch"){
			//print ("on");
			if(Input.GetMouseButton(0)){
				on.turnOn();
			}
		}
		if(c.tag == "Light"){
			if(Input.GetMouseButton(0)){
				light.turnOn();
			}
		}
	}
	void OnTriggerExit(Collider c){
		if(c.tag == "Switch"||c.tag == "Light"){
			hand.anim = false;
		}
	}

}
