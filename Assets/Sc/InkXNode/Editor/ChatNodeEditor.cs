using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace XNode.DialogGraph
{  
    [CustomEditor(typeof(ChatNode))]
    public class ChatNodeEditor : Editor
    {
        private SerializedProperty chatClipsProperty;

        void OnEnable()
        {
            chatClipsProperty = serializedObject.FindProperty("ChatClips");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(chatClipsProperty, true);

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
        
    }
}

