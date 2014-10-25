using UnityEngine;
using System.Collections;

public class BoyShipGo : MonoBehaviour {
	public FadeOut fade;
	public GameObject fireParticle, Police;
	float speed, speedMax, accelerate;
	bool move, policeMove, faded;
	// Use this for initialization
	void Start () {
		speed = 0;
		speedMax = 50;
		accelerate = 5;
		move = false;
		policeMove = false;
		faded = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(speed < speedMax && move){
			speed += accelerate * Time.deltaTime;
		}
		if(move){
			transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
		}
		if(transform.position.x > 18){
			Police.transform.Translate(new Vector3(speed/2  * Time.deltaTime, 0, 0));
		}
		if(Police.transform.position.x > 28 && faded){
			faded = false;
			StartCoroutine(fading());
		}
	
	}
	void OnTriggerEnter(Collider c){
		if(c.tag == "BoyShip"){
			//c.transform.Translate(new Vector3(0,0,20));
			c.GetComponent<MeshRenderer>().renderer.enabled = false;
			c.GetComponent<PlayerControl>().speed = 0;
			c.gameObject.transform.GetChild(2).gameObject.SetActive(false);
			c.gameObject.transform.GetChild(1).gameObject.SetActive(false);
			StartCoroutine(fire());
		}
	}
	IEnumerator fire(){
		PoliceAnim.start = true;
		fireParticle.transform.localPosition = new Vector3 (-1.2f, 0, 0.4f);
		yield return new WaitForSeconds (1f/4);
		fireParticle.transform.localPosition = new Vector3 (-1.0f, 0, 0.4f);
		yield return new WaitForSeconds (1f/4);
		fireParticle.transform.localPosition = new Vector3 (-0.5f, 0, 0.4f);
		yield return new WaitForSeconds (1f);
		fireParticle.transform.localPosition = new Vector3 (-1.2f, 0, 0.4f);
		yield return new WaitForSeconds (1f/4);
		fireParticle.transform.localPosition = new Vector3 (-1.0f, 0, 0.4f);
		yield return new WaitForSeconds (1f/4);
		fireParticle.transform.localPosition = new Vector3 (-0.5f, 0, 0.4f);
		yield return new WaitForSeconds (1f);

		fireParticle.transform.localPosition = new Vector3 (-1.2f, 0, 0.4f);
		yield return new WaitForSeconds(0.5f);
		move = true;
	}
	IEnumerator fading(){
		fade.fadeOut ();
		yield return new WaitForSeconds(2f);
		Application.LoadLevel ("GamePlay-Stage1");
	}
}
