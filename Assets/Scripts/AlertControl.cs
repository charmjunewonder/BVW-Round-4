using UnityEngine;
using System.Collections;

public class AlertControl : MonoBehaviour {
	MeshRenderer mesh;
	public float anim_time;
	bool fadeout, fadein;
	//float ori_a;
	// Use this for initialization
	void Start () {
		fadeout = false;
		fadein = false;
		mesh = GetComponent<MeshRenderer> ();
		//ori_a = mesh.material.color.a;
		//fadeOut ();
	}
	
	// Update is called once per frame
	void Update () {
		if(fadein){
			if(mesh.material.color.a < 1){
				mesh.material.color += new Color(0, 0, 0, Time.deltaTime * 2 / anim_time);
			}
			else{
				fadein = false;
				fadeout = true;
			}
		}
		if(fadeout){
			if(mesh.material.color.a > 0){
				mesh.material.color -= new Color(0, 0, 0, Time.deltaTime * 2 / anim_time);
			}
			else{
				fadeout = false;
			}
		}

	}
	public void fadeStart(){
		fadein = true;
	}
}
