using UnityEngine;
using System.Collections;

public class HandAnimation : MonoBehaviour {
	public GameObject hand1, hand2;
	public bool anim;
	bool hold, transition;
	// Use this for initialization
	void Start () {
		transition = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(anim && transition){
			if(hold){
				hold = false;
				transition = false;
				hand1.SetActive(false);
				hand2.SetActive(true);
				StartCoroutine(wait (0.9f));

			}
			else{
				hold = true;
				transition = false;
				hand2.SetActive(false);
				hand1.SetActive(true);
				StartCoroutine(wait (0.3f));
			}
		}
	}
	IEnumerator wait(float t){
		yield return new WaitForSeconds (t);
		transition = true;
	}
}
