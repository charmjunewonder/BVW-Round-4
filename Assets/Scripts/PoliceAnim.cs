using UnityEngine;
using System.Collections;

public class PoliceAnim : MonoBehaviour {
	public static bool start;
	public GameObject p1, p2;
	float speed = 3;
	bool turn, chase;
	Vector3 temp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(start){
			start = false;
			p1.SetActive(true);
			p2.SetActive(true);
			StartCoroutine(wait2chase());
		}
		else if(turn){
			turn = false;
			p1.transform.eulerAngles = new Vector3 (0, -90, 0);
			p2.transform.eulerAngles = new Vector3 (0, -90, 0);
			chase = true;
		}
		else if(chase){
			p1.GetComponent<Animator>().SetBool("Walk", true);
			p2.GetComponent<Animator>().SetBool("Walk", true);
			temp = new Vector3(2.5f, -7, 0) - p1.transform.position;
			p1.transform.Translate(temp.normalized * speed * Time.deltaTime);
			temp = new Vector3(2.5f, -10, 0) - p1.transform.position;
			p2.transform.Translate(temp.normalized * speed * Time.deltaTime);
		}
	}
	IEnumerator wait2chase(){
		yield return new WaitForSeconds(1f);
		turn = true;
	}
}
