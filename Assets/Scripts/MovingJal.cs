using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MovingJal : MonoBehaviour {

	public GameObject jal;

	public Vector3 toPosition1;
	public float moveInterval1 = 0.1f;
	public float speed1 = 10.0f;

	public bool isScale1 = false;
	public float scaleSpeed1 = 0.1f;
	public float scaleInterval1 = 0.1f;
	public int scaleCount1 = 10;
	
	public Vector3 toPosition2;
	public float moveInterval2 = 0.1f;
	public float speed2 = 10.0f;

	public Vector3 toPosition3;
	public float moveInterval3 = 0.1f;
	public float speed3 = 10.0f;

	public bool disappearBeforeMoving = false;
	public bool disappearAfterMoving = false;

	public float regenerateInterval = 1.0f;

	void Start(){
		renderer.enabled = true;
		if(disappearBeforeMoving){
			renderer.enabled = false;
		}	
		//MoveJal();
	}

	public void MoveJal(){
		StartCoroutine(DoMoveJal());
	}

	public void moveJalWithPlane(){
		StartCoroutine(DoMoveJalWithPlane());
	}

	IEnumerator DoMoveJalWithPlane(){
		while(Vector3.Distance(transform.position, toPosition3) > 0.1f){
			//Vector3 direction = transform.position - toPosition;
			Vector3 direction = toPosition3 - transform.position;
			
			direction.Normalize();
			transform.Translate( direction * speed3 * Time.deltaTime, Space.World);
			yield return new WaitForSeconds(moveInterval3);
		}
	}

	IEnumerator DoMoveJal(){

		renderer.enabled = true;
//		if(isScale1){
//			for(int i = 0; i < scaleCount1; ++i){
//				transform.localScale += new Vector3(scaleSpeed1, scaleSpeed1, scaleSpeed1);
//				yield return new WaitForSeconds(scaleInterval1);
//			}
//		}
		while(Vector3.Distance(transform.position, toPosition1) > 0.1f){
			
			Vector3 direction = toPosition1 - transform.position;
			
			direction.Normalize();
			transform.Translate( direction * speed1 * Time.deltaTime, Space.World);
			if(isScale1){
				transform.localScale += new Vector3(scaleSpeed1, scaleSpeed1, scaleSpeed1);
			}
			yield return new WaitForSeconds(moveInterval1);
		}
		while(Vector3.Distance(transform.position, toPosition2) > 0.1f){
			
			Vector3 direction = toPosition2 - transform.position;
			
			direction.Normalize();
			transform.Translate( direction * speed2 * Time.deltaTime, Space.World);

			yield return new WaitForSeconds(moveInterval2);
		}
		if(disappearAfterMoving){
			renderer.enabled = false;
		}
	}
}
