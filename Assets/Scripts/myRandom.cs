using UnityEngine;
using System.Collections;

public class myRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Random.seed = (int)System.DateTime.Now.Ticks;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static int aInt(int a, int b){
		return (Mathf.RoundToInt (Random.value * 10000) % (b - a) + a);
	}
	public static float aFloat(float a, float b){
		return (Random.value * (b - a) + a);
	}
}
