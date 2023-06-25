using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XNode;

namespace XNode.DialogGraph
{
    public class startdialog : DialogBase ,IGetValues
    {
        [Output] public NodePort index;

        public string GetInkText()
        {
            string var0 = "VAR player_name = \"\" ";
            string var1 = "VAR charTex_path = \"\" ";
            string var2 = "VAR backTex_path = \"\" ";
            var output = GetPort("index");
            
            StringBuilder s = new StringBuilder();
            //文本的变量定义部分
            s.Append(var0 + "\n");
            s.Append(var1 + "\n");
            s.Append(var2 + "\n");
            
            
            s.Append("-> part" + this.partID + "\n");
            s.Append("= part" +this.partID + "\n");
            s.Append("-> part");
            s.Append(((DialogBase)output.GetConnection(0).node).partID + "\n");

            return s.ToString();
        }
    }
}