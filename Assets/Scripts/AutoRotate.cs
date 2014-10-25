using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {
	public float RotateSpeed = 150;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));
	
	}
}
