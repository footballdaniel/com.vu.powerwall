using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Powerwall))]
    public class CameraControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            _controller = (Powerwall)target;

            EditorGUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(" ");
            var isButtonPressed = GUILayout.Button("Calibrate Space");
            EditorGUILayout.EndHorizontal();
            
            if(isButtonPressed)
                _controller.CalibrateOrigin();
        }

        Powerwall _controller;
    }
}
