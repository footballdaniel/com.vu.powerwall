using UnityEditor;
using UnityEngine;
using VROOM.Scripts;

namespace VROOM
{
    [CustomEditor(typeof(PowerwallController))]
    public class CameraControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            _controller = (PowerwallController)target;

            EditorGUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(" ");
            var isButtonPressed = GUILayout.Button("Calibrate Space");
            EditorGUILayout.EndHorizontal();
            
            if(isButtonPressed)
                _controller.CalibrateOrigin();
        }

        PowerwallController _controller;
    }
}
