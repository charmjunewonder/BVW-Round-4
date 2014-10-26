using UnityEngine;
using System.Collections;
using Leap;

public class SecretRoomController : MonoBehaviour {

	public HandController handController;
	public GameObject monitor;
	public GameObject monitorCenter;
	public Vector3 cameraOriginalPosition;
	public Vector3 cameraApplePosition;
	public float moveInterval = 0.03f;
	public float speed = 10.0f;
	private bool grabSuccessful = false;
	private bool startToMove = false;
	// Use this for initialization
	void Start () {
		monitor.renderer.enabled = false;
		Camera.main.transform.position = cameraOriginalPosition;
		StartCoroutine("flashLightSlow");
	}

	IEnumerator flashLightSlow(){
		while(true){
			monitor.renderer.enabled = false;
			yield return new WaitForSeconds(0.5f);
			monitor.renderer.enabled = true;
			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator flashLightFast(){
		while(true){
			monitor.renderer.enabled = false;
			yield return new WaitForSeconds(0.5f);
			monitor.renderer.enabled = true;
			yield return new WaitForSeconds(0.2f);
		}
	}

	IEnumerator moveCamera(){
		Camera camera = Camera.main;
		yield return new WaitForSeconds(2.0f);
		startToMove = true;
		while(Vector3.Distance(camera.transform.position, cameraApplePosition) > 0.1f){
			Vector3 direction = cameraApplePosition - camera.transform.position;
			
			direction.Normalize();
			camera.transform.Translate( direction * speed * Time.deltaTime, Space.World);
			yield return new WaitForSeconds(moveInterval);
		}
		StopCoroutine("flashLightFast");
		Debug.Log("Play Movie");
		//startToPlay = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!startToMove || handController == null)
			return;
		Vector handPosition = handController.GetComponent<HandController>().getFirstHandPosition();
		handPosition *= 0.001f;
		if( (Mathf.Abs(handPosition.x - monitorCenter.transform.position.x) < 2.3f
			|| Mathf.Abs(handPosition.y - monitorCenter.transform.position.y) < 1.0f)
		 	&& !startToMove){
			StopCoroutine("flashLightSlow");
			StartCoroutine("flashLightFast");
			StartCoroutine(moveCamera());
		}
	}
}
