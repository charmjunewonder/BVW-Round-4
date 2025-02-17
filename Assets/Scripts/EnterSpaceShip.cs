﻿using UnityEngine;
using System.Collections;

public class EnterSpaceShip : MonoBehaviour {
	public FadeOut fade;
	public PlayerControl player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c){
		if(c.tag == "BoyShip"){
			StartCoroutine(EnterNext());
		}
	}
	IEnumerator EnterNext(){
		audio.Play ();
		fade.gameObject.SetActive (true);
		player.speed = 0;
		fade.fadeOut ();
		yield return new WaitForSeconds(1);
		Application.LoadLevel ("SpaceShip");
	}
}
