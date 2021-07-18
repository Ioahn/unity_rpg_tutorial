using System;
using Editor.Windows;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Editor.Views
{
    [Serializable]
    public class NodeProperty: ViewBase
    
    {
        public NodeProperty(NodeEditor editor) : base("Property View", editor)
        {
        }

        public override void UpdateView(Rect editorRect, Rect percentageRect)
        {
            base.UpdateView(editorRect, percentageRect);
            
            GUI.Box(viewRect, viewTitle, viewSkin.GetStyle("ViewBG"));
        }
    }
}