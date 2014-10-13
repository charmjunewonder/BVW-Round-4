using UnityEngine;
using System.Collections;

public class Bang : MonoBehaviour {

	public float speeddown, speedup, lag;
	bool down, up, ready, press;

	// Use this for initialization
	void Start () {
		//lag = 0.5f;
		ready = true;
		speeddown = 80;
		speedup = 20;
	}
	
	// Update is called once per frame
	void Update () {
		if(!ready){
			press = false;
		}
		else if(press){
			ready = false;
			press = false;
			down = true;
		}

		if(down){
			if(transform.position.y <= 15){
				down = false;
				StartCoroutine(readyforUp());
			}
			else{
				transform.Translate(new Vector3(0, -speeddown * Time.deltaTime, 0));
			}
		}
		if(up){
			if(transform.position.y >= 30){
				up = false;
				StartCoroutine(readyforDown());
			}
			else{
				transform.Translate(new Vector3(0, speedup * Time.deltaTime, 0));
			}
		}
	}
	public void bangTrigger(){
		press = true;
	}
	IEnumerator readyforUp(){

		yield return new WaitForSeconds (lag);
		up = true;
	}
	IEnumerator readyforDown(){

		yield return new WaitForSeconds(lag);
		ready = true;
	}
}
