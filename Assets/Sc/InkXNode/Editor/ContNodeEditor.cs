using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XNodeEditor;
using XNode;
using XNode.DialogGraph;

[CustomNodeEditor(typeof(ConNode))]
public class ContNodeEditor : XNodeEditor.NodeEditor
{
    private ConNode _conNode;

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();
        
        _conNode = target as ConNode;

        

        /*// 绘制 Sprite 选择框
        _conNode.background = (Texture)EditorGUILayout.ObjectField("Backpack", _conNode.background, typeof(Texture), false);
        _conNode.chasprite = (Texture)EditorGUILayout.ObjectField("face", _conNode.chasprite, typeof(Texture), false);
        // 绘制其它字段
        _conNode.speaker = EditorGUILayout.TextField("Speaker", _conNode.speaker);
        _conNode.contents = EditorGUILayout.TextArea(_conNode.contents.ToString(),GUILayout.Height(100));

        //端点绘制
        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("title"));
        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("next"));

        // 将字段值更新到节点
        serializedObject.Update();
        SerializedProperty backpackProperty = serializedObject.FindProperty("backpack");
        SerializedProperty characterProperty = serializedObject.FindProperty("chasprite");
        
        if (EditorGUI.EndChangeCheck())
        {
            NodeEditorWindow.current.Repaint();
            serializedObject.ApplyModifiedProperties();
        }*/
        //serializedObject.ApplyModifiedProperties();
    }
}
