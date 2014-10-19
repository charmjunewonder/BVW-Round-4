using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {
	public float speed, last;
	bool rise = true, fall = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(rise){
			transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
			StartCoroutine(up());
		}
		else{
			transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
			StartCoroutine(down());
		}
	
	}
	IEnumerator up(){
		yield return new WaitForSeconds(last);
		rise = false;
		fall = true;
	}
	IEnumerator down(){
		yield return new WaitForSeconds(last);
		fall = false;
		rise = true;
	}
}
