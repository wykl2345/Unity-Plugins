using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace XNode.DialogGraph
{
    [NodeWidth(300),NodeTint(75,140,20),Serializable]
    public class ChatNode : DialogBase, IGetValues
    {
        [Input] public NodePort beforeNode; 
        public List<ChatClip> ChatClips = new List<ChatClip>();
        [Output] public NodePort nextPort;
        
        public string GetInkText()
        {
            var output = GetPort("nextPort");
            if (!output.IsConnected)
            {
                string store = ConnectChat();
                return store + "-> END\n";
            }
            else
            {
                var connection = output.GetConnection(0);
                string store = ConnectChat();
                return store + $"-> part{((DialogBase)connection.node).partID}" + "\n";
            }
        }

        string ConnectChat()
        {
            StringBuilder inkCont = new StringBuilder();

            string Nodetittle = "= part" + partID + "\n";
            inkCont.Append(Nodetittle);
            for (int i = 0; i < ChatClips.Count; i++)
            {
                string tittle = "= part" + partID + "_" + $"{i}" + "\n";
                string thischat = "->" + tittle.Substring(2).Trim() + "\n";
                string nexttille = "= part" + partID + "_" + $"{i + 1}" + "\n";
                string nextchat = "->" + nexttille.Substring(2).Trim() +"\n";
                string speakerName = SPEAK_NAME_VAR + "\"" + ChatClips[i].speaker + "\"" + "\n";
                string point = "+[继续] " + nextchat;
                
                string face_path = AssetDatabase.GetAssetPath(ChatClips[i].chasprite);
                string back_path = AssetDatabase.GetAssetPath(ChatClips[i].background);
                
                string face = FACE_PATH_VAR + "\"" + face_path + "\"" + "\n";
                string back = BACK_PATH_VAR + "\"" + back_path + "\"" + "\n";

                inkCont.Append(thischat);
                inkCont.Append(tittle);
                inkCont.Append(speakerName);
                inkCont.Append(face);
                inkCont.Append(back);
                inkCont.Append(ChatClips[i].contents + "\n");
                if(i!=ChatClips.Count - 1)
                    inkCont.Append(point);
            }
            return inkCont.ToString();
        }
        
        

        [Serializable]
        public class ChatClip
        {
            public Sprite background;
            public Sprite chasprite;
            public string speaker;
            [TextArea(4,6)]public string contents;
        }
    }
    
}
