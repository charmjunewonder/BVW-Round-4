using UnityEngine;
using System.Collections;

public class HitBird : MonoBehaviour {
	public GameObject breakdown, blast;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c){
		if(c.tag == "Bird"){
			GameObject temp;
			//breakdown.audio.Play();
			temp = Instantiate(breakdown) as GameObject;
			temp.SetActive(true);
			temp = Instantiate(blast, transform.position, Quaternion.identity) as GameObject;
			temp.SetActive(true);
			Debug.Log ("HitBird");
			Destroy(c.gameObject);
			Stage2Control.birdNum --;

			Destroy (gameObject);
		}
	}
}
