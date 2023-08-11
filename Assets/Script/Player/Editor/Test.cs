using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(PlayerUpperLimit))]
public class Test : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var test = (PlayerUpperLimit)target;

        if(GUILayout.Button("TesT Button"))
        {
            test.Test();
        }
    }

}
