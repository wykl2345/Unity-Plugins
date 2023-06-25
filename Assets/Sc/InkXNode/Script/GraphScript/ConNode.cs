using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ink.Parsed;
using UnityEditor;
using UnityEngine;
using XNode;

namespace XNode.DialogGraph
{
    
    [NodeWidth(300),NodeTint(75,140,210)]
    public class ConNode : DialogBase, IGetValues
    {
        [Input] public NodePort BeforePort;
        public Sprite background;
        public Sprite chasprite;
        public string speaker;
        [TextArea(4,6)]
        public string contents;
        [Output] public NodePort NodePort;

        public override object GetValue(NodePort port)
        {
            return null;
        }

        public string GetInkText()
        {
            NodePort nextPort = GetPort("NodePort");
            NodePort before = GetPort("BeforePort");
            string face_path = AssetDatabase.GetAssetPath(chasprite);
            string back_path = AssetDatabase.GetAssetPath(background);
            StringBuilder s = new StringBuilder();
            
            //无导入端点的情况，就是没有引入到这段对话的情况
            if (!before.IsConnected)
            {
                StringBuilder nbs = new StringBuilder();
                nbs.Append("= part" + this.partID + "\n");
                return nbs.ToString();
            }

            //没有尾端端点的情况，就是默认为直接结束对话
            if (!nextPort.IsConnected)
            {
                s.Append("= part" + this.partID + "\n");
                s.Append(SPEAK_NAME_VAR + "\"" + speaker + "\"" + "\n");
                s.Append(FACE_PATH_VAR + "\"" + face_path + "\"" + "\n");
                s.Append(BACK_PATH_VAR + "\"" + back_path + "\"" + "\n");
                s.Append(this.contents + "\n");
                s.Append("-> END\n");
                
                return s.ToString();
            }

            //
            NodePort connection = nextPort.GetConnection(0);
            if (connection == null)
                return "";

            //AssetDatabase.GetAssetPath(Asset)，Asset没有索引时返回的是”“，空字符串不是空索引

            string point = "+[继续] -> part";
            string next = ((DialogBase)connection.node).partID.ToString();
            
            s.Append("= part" + this.partID + "\n");
            s.Append(SPEAK_NAME_VAR + "\"" + speaker + "\"" + "\n");
            
            //背景要看改不改，不改就不动（想了想有时候为空还要给张空白图片不是很方便，干脆每次都绑定）
            /*if(!face_path.Equals(""))
                s.Append(FACE_PATH_VAR + "\"" + face_path + "\"" + "\n");
            if(!back_path.Equals(""))
                s.Append(BACK_PATH_VAR + "\"" + back_path + "\"" + "\n");
                */

            s.Append(FACE_PATH_VAR + "\"" + face_path + "\"" + "\n");
            s.Append(BACK_PATH_VAR + "\"" + back_path + "\"" + "\n");
            
            s.Append(this.contents + "\n");
            s.Append(point);
            s.Append(next+"\n");

            InkDia = s.ToString();

            return InkDia;
        }
    }

    public interface IGetValues
    {
        public string GetInkText();
    }
}
