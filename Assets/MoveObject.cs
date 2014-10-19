using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	public Vector3 fromPostion;
	public Vector3 toPosition;
	public float startDelay = 0;
	public float moveInterval = 0.1f;
	public bool playOnAwake = false;
	public float speed = 10.0f;

	// Use this for initialization
	void Start () {
		if(playOnAwake){
			moveObject();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveObject(){
		StartCoroutine(DoMoveOject());
	}

	IEnumerator DoMoveOject(){
		yield return new WaitForSeconds(startDelay);
		while(Vector3.Distance(transform.position, toPosition) > 0.1f){
			Vector3 direction = transform.position - toPosition;
			direction.Normalize();
			transform.Translate( direction * speed * Time.deltaTime);
			yield return new WaitForSeconds(moveInterval);
		}
	}
}
