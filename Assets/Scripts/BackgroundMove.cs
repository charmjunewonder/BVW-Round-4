using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {
	public FadeOut screen;
	public float bgSpeed, stopPos;
	public string loadLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, bgSpeed * Time.deltaTime, 0));
		if(transform.position.y > stopPos){
			StartCoroutine(end ());
		}
	}
	IEnumerator end(){
		screen.fadeOut();
		yield return new WaitForSeconds (2f);
		//bgSpeed = 0;
		Application.LoadLevel(loadLevel);
	}
}
