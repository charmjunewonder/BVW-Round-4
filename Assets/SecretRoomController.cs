using UnityEngine;
using System.Collections;
using Leap;

public class SecretRoomController : MonoBehaviour {

	public HandController handController;
	public GameObject monitor;
	public GameObject monitorCenter;
	public Vector3 backgroundOriginalPosition;
	public Vector3 backgroundPlayPosition;
	public float moveInterval = 0.03f;
	public float speed = 20.0f;
	public GameObject background;
	public CubeCollider cubeCollider;
	public MovieTexture[] reports;
	public Texture[] dateOfReports;
	public GameObject moviePlane;
	private bool grabSuccessful = false;
	private bool startToMove = false;
	// Use this for initialization
	void Start () {
		monitor.renderer.enabled = false;
		background.transform.position = backgroundOriginalPosition;
		background.transform.localScale = new Vector3(1, 1, 1);

		StartCoroutine("flashLightSlow");
		StartCoroutine (playMovie ());

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
			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator moveBackground(){
		yield return new WaitForSeconds(2f);

		while(Vector3.Distance(background.transform.position, backgroundPlayPosition) > 0.1f){
			Vector3 direction = backgroundPlayPosition - background.transform.position;
			
			direction.Normalize();
			background.transform.Translate( direction * speed * Time.deltaTime, Space.World);
			yield return new WaitForSeconds(moveInterval);
		}
		StopCoroutine("flashLightFast");
		Debug.Log("Play Movie");
		StartCoroutine (playMovie ());
		//startToPlay = true;
	}

	IEnumerator scaleBackground(){
		yield return new WaitForSeconds(2.0f);
		for(int i = 0; i < 13; i++){
			background.transform.localScale += new Vector3(0.1f, 0.1f, 0f);
			yield return new WaitForSeconds(0.03f);
			
		}
	}

	IEnumerator playMovie(){
		int[] time = {20, 7};
		for (int i = 0; i < 2; ++i) {
			moviePlane.renderer.material.mainTexture = dateOfReports[i];

			for(int j = 0; j < 20; ++j){
				moviePlane.renderer.material.color -= new Color(0, 0, 0, Time.deltaTime*2);
				yield return new WaitForSeconds(0.1f);

			}

			moviePlane.renderer.material.color += new Color(0, 0, 0, 1);

			moviePlane.renderer.material.mainTexture = reports[i];
			reports [i].Play ();
			audio.clip = reports [i].audioClip;
			audio.Play ();
			
			yield return new WaitForSeconds(time[i]);
		}
		Debug.Log("Play Movie");

		Application.LoadLevel("GamePlay-StageEmergency");

	}

	void hideHand(){
		handController.hideHands = true;
		GameObject rightHandG = GameObject.Find("CleanRobotRightHand(Clone)");
		if(rightHandG != null){
			Destroy(rightHandG);
		}
		GameObject leftHandG = GameObject.Find("CleanRobotLeftHand(Clone)");
		if(leftHandG != null){
			Destroy(leftHandG);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(handController == null)
			return;
		if(!cubeCollider.isTriggered)
			return;
		cubeCollider.gameObject.SetActive(false);

		if(!startToMove){
			StopCoroutine("flashLightSlow");
			StartCoroutine("flashLightFast");
			startToMove = true;
			hideHand();
			StartCoroutine(moveBackground());
			StartCoroutine(scaleBackground());

		}
	}
}
