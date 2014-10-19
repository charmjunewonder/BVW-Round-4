using UnityEngine;
using System.Collections;

public class Fadeout : MonoBehaviour {
	public MeshRenderer mesh;
	public float anim_time;
	bool startfade;
	float ori_a;
	// Use this for initialization
	void Start () {
		startfade = false;
		ori_a = mesh.material.color.a;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(startfade){
			if(mesh.material.color.a > 0){
				mesh.material.color -= new Color(0, 0, 0, ori_a * Time.deltaTime / anim_time);
			}
		}
	}
	public void fadeout(){
		startfade = true;
	}
}
