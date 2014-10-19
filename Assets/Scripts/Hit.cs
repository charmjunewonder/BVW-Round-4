using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {
	public GameObject breakdown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider c){
		if(c.tag == "BoyShip"){
			//Destroy(c.gameObject);
			Destroy(gameObject);

		}
		if(c.tag == "EnemyShip"){
			GameObject temp;
			//breakdown.audio.Play();
			temp = Instantiate(breakdown) as GameObject;
			temp.SetActive(true);

			Destroy(c.gameObject);
			Destroy(gameObject);
			
		}
	}
}
