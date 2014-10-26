using UnityEngine;
using System.Collections;

public class TurnOntheLight : MonoBehaviour {
	public GameObject vision;
	public Light DirectionLight;
	public HandAnimation hand;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void turnOn(){
		vision.transform.localScale *= 1.2f;
		DirectionLight.intensity *= 2.5f;
		hand.anim = false;
		Destroy (gameObject);
	}

}
