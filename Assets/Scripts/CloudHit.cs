using UnityEngine;
using System.Collections;

public class CloudHit : MonoBehaviour {
	public GameObject breakdown, blast;
	public HitShake beHit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c){
		if(c.tag == "BoyShip"){
			beHit.hit();
			GameObject temp;
			//breakdown.audio.Play();
			temp = Instantiate(breakdown) as GameObject;
			temp.SetActive(true);
			temp = Instantiate(blast, transform.position, Quaternion.identity) as GameObject;
			temp.SetActive(true);
			//Destroy(c.gameObject);
			//Destroy(gameObject);
			
		}
		if(c.tag == "EnemyShip"){
			GameObject temp;
			//breakdown.audio.Play();
			temp = Instantiate(breakdown) as GameObject;
			temp.SetActive(true);
			temp = Instantiate(blast, transform.position, Quaternion.identity) as GameObject;
			temp.SetActive(true);
			
			Destroy(c.gameObject);
			//Destroy(gameObject);
			
		}
	}
}
