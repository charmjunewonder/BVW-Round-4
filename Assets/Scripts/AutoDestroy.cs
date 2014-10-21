using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (KillSelf ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator KillSelf(){
		yield return new WaitForSeconds(6);
		}
}
