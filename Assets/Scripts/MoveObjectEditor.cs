using UnityEngine;
using System.Collections;

using UnityEditor;

[CustomEditor(typeof(MoveObject))]

public class MoveObjectEditor : Editor {

    public override void OnInspectorGUI()
    {
		MoveObject myTarget = (MoveObject)target;
  		myTarget.toPosition = EditorGUILayout.Vector3Field("To Position", myTarget.toPosition);
  		myTarget.moveInterval = EditorGUILayout.FloatField("Move Interval", myTarget.moveInterval);
  		myTarget.speed = EditorGUILayout.FloatField("Speed", myTarget.speed);
       	
       	myTarget.isScale = EditorGUILayout.Toggle("Is Scale", myTarget.isScale);
    	if(myTarget.isScale){
      		myTarget.scaleSpeed = EditorGUILayout.FloatField("Scale Speed", myTarget.scaleSpeed);
    	}
    	myTarget.disappearBeforeMoving = EditorGUILayout.Toggle("Disappear Before Moving", myTarget.disappearBeforeMoving);
    	myTarget.disappearAfterMoving = EditorGUILayout.Toggle("Disappear After Moving", myTarget.disappearAfterMoving);

    }
}
