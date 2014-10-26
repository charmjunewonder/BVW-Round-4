using UnityEngine;
using System.Collections;

public class ScannerBehavior : MonoBehaviour {
	public Vector3 destination;
	public Transform wave;
	public GameObject apple, radio;
	public LineRenderer target;
	public float MoveSpeed, AnimSpeed;
	Vector3 scalar;
	bool move, scan, emit, focus;
	const float threshold = 0.2f;
	// Use this for initialization
	void Start () {
		move = true;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dis = destination - transform.position;
		dis.z = 0;
		if(dis.magnitude > threshold && move){
			scalar = transform.localScale;
			if(scalar.magnitude <= Vector3.one.magnitude){
				scalar += new Vector3(AnimSpeed/3 * Time.deltaTime, AnimSpeed/3 * Time.deltaTime, AnimSpeed/3 * Time.deltaTime);
			}
			transform.localScale = scalar;
			transform.Translate(MoveSpeed * dis.normalized * Time.deltaTime);
		}
		else if(move){
			transform.localScale = Vector3.one;
			move = false;
			scan = true;
		}
		else if(scan){
			scan = false;
			StartCoroutine(emitWave());
		}
		else if(emit){
			scalar = wave.transform.localScale;
			if(scalar.magnitude <= (Vector3.one * 2).magnitude){
				scalar += new Vector3(AnimSpeed * Time.deltaTime, AnimSpeed * Time.deltaTime, AnimSpeed * Time.deltaTime);
			}
			else{
				scalar = Vector3.zero;
			}
			wave.transform.localScale = scalar;
		}
		else if(focus){

		}
	}
	IEnumerator emitWave(){
		emit = true;
		yield return new WaitForSeconds (3);
		emit = false;
		wave.transform.localScale = Vector3.one * 2;
		Vector3 dis = apple.transform.position - transform.position; 
		dis.z = 0;
		if(dis.magnitude < 2.3){
			target.SetPosition(0, transform.position);
			target.SetPosition(1, transform.position + dis.normalized * 2.3f);
			AppleSpotted.SpotNum++;
			//radio.GetComponent<AutoRotate>().RotateSpeed = 0;
		}
		focus = true;
	}
}
