using UnityEngine;
using System.Collections;

public class LineRenderFlash : MonoBehaviour {
	public float speed;
	public Material m;
	bool up, down;
	// Use this for initialization
	void Start () {
		up = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(up){
			if(m.GetColor("_TintColor").a >= 0.3f){
				up = false;
				down = true;
			}
			else{
				m.SetColor("_TintColor", m.GetColor("_TintColor")+new Color(0,0,0,speed*Time.deltaTime));
			
			}
		}
		else if(down){
			if(m.GetColor("_TintColor").a < 0){
				up = true;
				down = false;
			}
			else{
				m.SetColor("_TintColor", m.GetColor("_TintColor")-new Color(0,0,0,speed*Time.deltaTime));
				
			}
		}
	}
}
