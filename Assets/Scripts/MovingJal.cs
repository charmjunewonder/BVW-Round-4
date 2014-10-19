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

	public Vector3 toPosition2;
	public float moveInterval2 = 0.1f;
	public float speed2 = 10.0f;

	public bool disappearBeforeMoving = false;
	public bool disappearAfterMoving = false;

	public float regenerateInterval = 1.0f;


	public void MoveJalAndRegenerate(){
		StartCoroutine(GenerateJal());
		Debug.Log("jfla");
	}

	IEnumerator GenerateJal(){
		//while(true){

			GameObject jalClone = Instantiate(jal) as GameObject;
			Debug.Log("jfasdfsdafsdfla");
			
			jalClone.transform.position = jal.transform.position;
			jalClone.transform.parent = jal.transform;
			jalClone.GetComponent<MovingJal>().disappearBeforeMoving = disappearBeforeMoving;
			jalClone.GetComponent<MovingJal>().disappearAfterMoving = disappearAfterMoving;
			StartCoroutine(DoMoveJal(jalClone));
			yield return new WaitForSeconds(regenerateInterval);

		//}
	}

	public void moveJal(GameObject jalClone){
		StartCoroutine(DoMoveJal(jalClone));
		
	}

	IEnumerator DoMoveJal(GameObject jalClone){

		jalClone.renderer.enabled = true;
		while(Vector3.Distance(jalClone.transform.position, toPosition1) > 0.1f){
			
			Vector3 direction = toPosition1 - jalClone.transform.position;
			
			direction.Normalize();
			jalClone.transform.Translate( direction * speed1 * Time.deltaTime, Space.World);
			if(isScale1){
				jalClone.transform.localScale += new Vector3(scaleSpeed1, scaleSpeed1, scaleSpeed1);
			}
			yield return new WaitForSeconds(moveInterval1);
		}
		while(Vector3.Distance(jalClone.transform.position, toPosition2) > 0.1f){
			
			Vector3 direction = toPosition2 - jalClone.transform.position;
			
			direction.Normalize();
			jalClone.transform.Translate( direction * speed2 * Time.deltaTime, Space.World);

			yield return new WaitForSeconds(moveInterval2);
		}
		if(disappearAfterMoving){
			jalClone.renderer.enabled = false;
		}
	}
}
