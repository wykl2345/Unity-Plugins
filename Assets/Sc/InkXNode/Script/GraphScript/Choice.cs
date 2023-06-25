using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using XNode;


namespace XNode.DialogGraph
{
    public class Choice : DialogBase,IGetValues
    {
        [Input] public NodePort BeforePort;
        public Sprite background;
        public Sprite chasprite;
        public string speaker;
        [Output(dynamicPortList = true)] public List<ReSelect> selects;
        
        public override object GetValue(NodePort port)
        {
            /*if (port.fieldName == "selects")
            {
                StringBuilder s = new StringBuilder();
                s.Append("=" + this.GetHashCode().ToString() + "\n");
                s.Append("~ player_name = " + speaker + "\n");
                for (int i = 0; i < selects.Count; i++)
                {
                    if (selects[i].canRe)
                    {
                        s.Append("+");
                    }
                    else
                    {
                        s.Append("*");
                    }

                    s.Append(selects[i].contents + "\n");
                    var seli = GetPort($"selects {i}").GetConnection(0);
                    s.Append("->");
                    s.Append(seli.GetHashCode().ToString());
                }

                _inkDialog = s.ToString();
                return _inkDialog;
            }*/
            return null;
        }
        
        public string GetInkText()
        {
            if (selects.Count <= 0)
                return null;
            
            StringBuilder s = new StringBuilder();
            s.Append("= part" + this.partID + "\n");
            s.Append(SPEAK_NAME_VAR +"\""+ speaker +"\""+"\n");
            s.Append(FACE_PATH_VAR + "\"" + AssetDatabase.GetAssetPath(chasprite) + "\"" + "\n");
            s.Append(BACK_PATH_VAR + "\"" + AssetDatabase.GetAssetPath(background) + "\"" + "\n");
            
            for (int i = 0; i < selects.Count; i++)
            {
                var seli = GetPort($"selects {i}").GetConnection(0);

                if (seli is null)
                {
                    return "";
                }
                
                if (selects[i].canRe)
                {
                    s.Append("+ ");
                }
                else
                {
                    s.Append("* ");
                }
                s.Append("[" + selects[i].contents + "]" + "\n");
                
                s.Append("-> part");
                s.Append(((DialogBase)seli.node).partID + "\n");
            }
            _inkDialog = s.ToString();
            return _inkDialog;
        }
        
   
    }
    [System.Serializable]
    public class ReSelect
    {
        public bool canRe = false;
        [TextArea(4, 30)]
        public string contents;
    }
}
