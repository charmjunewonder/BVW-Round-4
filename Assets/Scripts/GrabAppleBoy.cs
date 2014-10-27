using UnityEngine;
using System.Collections;

public class GrabAppleBoy : MonoBehaviour {
	public Animator boy;
	public FadeOut fade;
	public GameObject model, ship;
	public bool init, back, go, rise;
	public float speed;
	// Use this for initialization
	void Start () {
		boy.SetBool("Walk", true);
		init = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(init){
			if(transform.position.x < 3.4f){
				transform.Translate (new Vector3(speed * Time.deltaTime, 0, 0));
			}
			else{
				audio.Stop();
				boy.SetBool("Walk",false);
				init = false;
				model.transform.Rotate(new Vector3(0, -90, 0));
				//gameObject.SetActive(false);
			}
		}
		if (back){
			boy.SetBool("Walk", true);
			back = false;
			model.transform.Rotate (new Vector3(0, -90, 0));
			go = true;
			audio.Play();
		}
		if(go){
			if(transform.position.x > 0){

				transform.Translate (new Vector3(-speed * Time.deltaTime, 0, 0));
			}
			else{
				audio.Stop ();
				boy.SetBool("Walk", false);
				back = false;
				go = false;
				transform.Translate(new Vector3(100, 0, 0));
				rise = true;
			}
		}
		if(rise){
			StartCoroutine(startSound());
			ship.transform.Translate(0, speed * Time.deltaTime, 0);
			fade.fadeOut();
		}
	}
	IEnumerator startSound(){

		ship.audio.Play();
		yield return new WaitForSeconds(1);
	}

}
