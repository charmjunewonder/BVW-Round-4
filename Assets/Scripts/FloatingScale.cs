using UnityEngine;
using System.Collections;

public class FloatingScale : MonoBehaviour {
	public float speed, last;
	bool rise = true, fall = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(rise){
			transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
			StartCoroutine(up());
		}
		else{
			transform.localScale -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
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
