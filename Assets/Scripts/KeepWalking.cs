using UnityEngine;
using System.Collections;

public class KeepWalking : MonoBehaviour {
	public Animator p;
	public float speed;
	// Use this for initialization
	void Start () {
		p.SetBool ("Walk", true);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= 0)
			transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
		else
			p.SetBool("Walk", false);
	}
}
