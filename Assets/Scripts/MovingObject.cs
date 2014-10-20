using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	public Vector3[] toPositions;
	public float[] moveIntervals;
	public float[] speeds;

	void Start(){

		//moveObject ();
	}

	public void moveObject(){
		StartCoroutine(DoMoveOject());
	}

	IEnumerator DoMoveOject(){
		for(int i = 0; i < toPositions.Length; ++i){
			while(Vector3.Distance(transform.position, toPositions[i]) > 0.1f){
				//Vector3 direction = transform.position - toPosition;
				Vector3 direction = toPositions[i] - transform.position;
				
				direction.Normalize();
				transform.Translate( direction * speeds[i] * Time.deltaTime, Space.World);

				yield return new WaitForSeconds(moveIntervals[i]);
			}
			Debug.Log("sdjfals");
		}
	}
}
