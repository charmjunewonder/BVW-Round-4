using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	MeshRenderer mesh;
	public float anim_time;
	bool startfade;
	//float ori_a;
	// Use this for initialization
	void Start () {
		startfade = false;
		mesh = GetComponent<MeshRenderer> ();
		//ori_a = mesh.material.color.a;
		//fadeOut ();
	}
	
	// Update is called once per frame
	void Update () {
		if(startfade){
			print (mesh.material.color.a);
			if(mesh.material.color.a < 1){
				mesh.material.color += new Color(0, 0, 0, Time.deltaTime / anim_time);
			}
		}
	}
	public void fadeOut(){
		startfade = true;
	}
}
