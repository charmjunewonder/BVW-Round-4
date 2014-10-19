using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {
	public float bgSpeed, stopPos;
	public int loadLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, bgSpeed * Time.deltaTime, 0));
		if(transform.position.y > stopPos){
			bgSpeed = 0;
			Application.LoadLevel(loadLevel);
		}
	}
}
