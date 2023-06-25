
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.DialogGraph
{
    public class DialogBase : Node
    {
        [HideInInspector]public int partID;
        protected const string SPEAK_NAME_VAR = "~ player_name = ";
        protected const string FACE_PATH_VAR = "~ charTex_path = ";
        protected const string BACK_PATH_VAR = "~ backTex_path = ";
        
        protected string _inkDialog;
        public string InkDia
        {
            get => _inkDialog;
            set => _inkDialog = value;
        }
    }
}

