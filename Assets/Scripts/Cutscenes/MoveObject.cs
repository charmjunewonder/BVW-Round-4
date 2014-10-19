using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MoveObject : MonoBehaviour {

	public Vector3 toPosition;
	public float moveInterval = 0.1f;
	public float speed = 10.0f;

	public bool isScale = false;
	public float scaleSpeed = 0.1f;

	public bool disappearBeforeMoving = false;
	public bool disappearAfterMoving = false;

	void Start(){
		gameObject.renderer.enabled = true;

		if(disappearBeforeMoving){
			gameObject.renderer.enabled = false;
		}

		moveObject ();
	}

	public void moveObject(){
		StartCoroutine(DoMoveOject());
	}

	IEnumerator DoMoveOject(){
		if(disappearBeforeMoving){
			gameObject.renderer.enabled = true;
		}
		while(Vector3.Distance(transform.position, toPosition) > 0.1f){
			Vector3 direction = transform.position - toPosition;
			direction.Normalize();
			transform.Translate( direction * speed * Time.deltaTime);
			if(isScale){
				transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
			}
			yield return new WaitForSeconds(moveInterval);
		}
		if(disappearAfterMoving){
			gameObject.renderer.enabled = false;
		}
	}
}
