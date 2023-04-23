using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Actor))]
public class ActorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Attack"))
        {
            Actor actor = (Actor)target;
            //actor.Attack();
        }
    }
}
