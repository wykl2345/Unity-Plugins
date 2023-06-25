using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNode.DialogGraph;
using UnityEditor;
using System.Linq;
using UnityEditorInternal;
using XNodeEditor;

[CustomNodeEditor(typeof(Choice))]
public class ChoiceNodeEditor : XNodeEditor.NodeEditor
{
    private Choice _choice;
    public override void OnBodyGUI()
    {
        
        base.OnBodyGUI();
        /*
        var oldColor = GUI.backgroundColor;
        // 调用base.OnBodyGUI方法
        base.OnBodyGUI();
        // 恢复之前修改的部分
        GUI.backgroundColor = oldColor;
        */
    }

    public override void OnHeaderGUI()
    {
        base.OnHeaderGUI();
    }
}

