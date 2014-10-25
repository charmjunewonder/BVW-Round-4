using UnityEngine;
using System.Collections;

public class EmitScanner : MonoBehaviour {
	public GameObject scanner;
	public Transform boyship, apple;
	public FadeOut fade;
	GameObject temp;
	public bool scaning, confirm;
	bool cooldown, end;
	float threshold = 0.2f, AnimSpeed = 1, MoveSpeed = 3;
	Vector3 scalar;
	// Use this for initialization
	void Start () {
		cooldown = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(scaning){
			if(Input.GetMouseButton(0) && cooldown){
				transform.GetChild(0).gameObject.SetActive(false);
				transform.GetChild(1).gameObject.SetActive(false);
				cooldown = false;
				StartCoroutine(launch());
			}
			else if(cooldown){
				transform.GetChild(0).gameObject.SetActive(true);
				transform.GetChild(1).gameObject.SetActive(true);
			}
		}
		if(confirm){
			transform.GetChild(0).gameObject.SetActive(false);
			//transform.GetChild(1).gameObject.SetActive(false);
			scaning = false;
			Vector3 dis = apple.position - transform.position;
			if(Input.GetMouseButton(0)&&dis.magnitude < threshold){
				confirm = false;
				end = true;
				StartCoroutine(ending());
			}                                                    
		}
		if(end){
			Vector3 dis = apple.position - boyship.position;
			dis.z = 0;
			if(dis.magnitude > threshold){
				scalar = boyship.localScale;
				if(scalar.x >= 0){
					scalar -= new Vector3(AnimSpeed/15 * Time.deltaTime, AnimSpeed/15 * Time.deltaTime, AnimSpeed/15 * Time.deltaTime);
				}
				//print (boyship.rotation.eulerAngles.x);
				if(boyship.rotation.eulerAngles.x >270){
					boyship.Rotate(new Vector3(AnimSpeed * 10 * Time.deltaTime, 0, 0));
				}
				boyship.localScale = scalar;
				boyship.Translate(MoveSpeed * dis.normalized * Time.deltaTime);
			}
		}
	}
	IEnumerator launch(){
		temp = Instantiate (scanner, boyship.position, Quaternion.identity) as GameObject;
		temp.SetActive (true);
		temp.GetComponent<ScannerBehavior> ().destination = transform.position;
		yield return new WaitForSeconds (3);
		cooldown = true;
	}
	IEnumerator ending(){
		yield return new WaitForSeconds(2);
		fade.fadeOut ();
		yield return new WaitForSeconds (3);
		Application.LoadLevel("Ends");
	}
}
