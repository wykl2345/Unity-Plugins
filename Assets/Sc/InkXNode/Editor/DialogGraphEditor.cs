using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ink.Parsed;
using UnityEditor;
using UnityEngine;
using XNode;
using XNode.DialogGraph;
using XNodeEditor;
using System.IO;
using Path = System.IO.Path;


[CustomEditor(typeof(DialogGraph))]
[CanEditMultipleObjects]
public class DialogGraphEditor : Editor
{
    private DialogGraph _dialogGraph;
    private List<Node> _nodes;
    StringBuilder con = new StringBuilder();
    public string SavePath;
    public string StoryName;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        GUILayout.Label("Node info",EditorStyles.boldLabel);
 
        SavePath = EditorGUILayout.TextField("Dialog");
        StoryName = EditorGUILayout.TextField($"{StoryName}");
        
        if (GUILayout.Button("Get Inky JSON file"))
        {
            _dialogGraph = target as DialogGraph;
            _nodes ??= _dialogGraph.nodes;
            for (int i = 0; i < _nodes.Count; i++)
            {
                var node = _nodes[i] as DialogBase;
                node.partID = i;
            }
            
            con.Clear();
            foreach (var node in _nodes)
            {
                var nodeinfo = node as IGetValues;
                con.Append(nodeinfo.GetInkText());
            }

            string contents = con.ToString();

            using (StreamWriter write = new StreamWriter(Path.Combine(Application.dataPath,SavePath,StoryName + ".ink")))
            {
                write.Write(contents);
            }
            
        }
        
        

    }

    
    
    
}