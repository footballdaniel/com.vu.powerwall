using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(PowerWall))]
    public class PowerWallEditor : UnityEditor.Editor
    {
        PowerWall _controller;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
		
            _controller = (PowerWall)target;

            EditorGUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(" ");
            var isButtonPressed = GUILayout.Button("Calibrate Space");
            EditorGUILayout.EndHorizontal();
		
            if(isButtonPressed)
                _controller.CalibrateOrigin();
        }
    }
}