using UnityEngine;
using System.Collections;
using Leap;
public class BoyBehavior : MonoBehaviour {
	public float moveSpeed;
	public bool useLeapMotion;
	public HandController handController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a")){
			transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
		}
		if(Input.GetKey("d")){
			transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
		}
		if(Input.GetKey("w")){
			transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
		}
		if(Input.GetKey("s")){
			transform.Translate(new Vector3(0, -moveSpeed * Time.deltaTime, 0));
		}

		if(transform.position.x >= StaticValues.worldboudary_x){
			transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
		}
		if(transform.position.x <= -StaticValues.worldboudary_x){
			transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
		}
		if(transform.position.y <= -StaticValues.worldboudary_y){
			transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
		}
		if(transform.position.y >= StaticValues.worldboudary_y){
			transform.Translate(new Vector3(0, -moveSpeed * Time.deltaTime, 0));
		}
		
		if(useLeapMotion){
			Vector currentPosition = handController.getFirstHandPosition();
			float y = Mathf.Clamp((currentPosition.y - 200)/20, -9.496778f, 9.496778f);
			float x = Mathf.Clamp(currentPosition.x/10, -9.496778f, 9.496778f);
			transform.position = new Vector3(x, y, -5);
		}

	}
}
