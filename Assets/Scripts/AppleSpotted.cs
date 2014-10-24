using UnityEngine;
using System.Collections;

public class AppleSpotted : MonoBehaviour {
	public static int SpotNum = 0;
	public EmitScanner cursor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(SpotNum >= 2){
			transform.GetChild(0).gameObject.SetActive(true);
			cursor.confirm = true;
		}
	}
}
