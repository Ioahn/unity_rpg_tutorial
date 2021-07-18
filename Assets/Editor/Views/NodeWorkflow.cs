using System;
using Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace Editor.Views
{
    public class NodeWorkflow: ViewBase
    {
        public NodeWorkflow(NodeEditor editor) : base("Work view", editor)
        {
        }

        public override void UpdateView(Rect editorRect, Rect percentageRect)
        {
            base.UpdateView(editorRect, percentageRect);
            
            GUI.Box(viewRect, viewTitle, viewSkin.GetStyle("ViewBG"));
        }

        public override void ProcessEvents(Event e)
        {
            base.ProcessEvents(e);

            if (viewRect.Contains(e.mousePosition))
            {
                Action handler = (
                        e.button == 0,
                        e.button == 1,
                        e.type == EventType.MouseDown,
                        e.type == EventType.MouseDrag,
                        e.type == EventType.MouseUp) switch
                    {
                        (true, _, true, _, _) => () => Debug.Log("asdf1"),
                        (true, _, _, true, _) => () => Debug.Log("asdf2"),
                        (true, _, _, _, true) => () => Debug.Log("asdf3"),
                        (_, true, true, _, _) => () => ShowContextMenu(e),
                        _ => () => { }
                    };

                handler();

            }
        }

        private void ShowContextMenu(Event e)
        {
            GenericMenu menu = new GenericMenu();
            
            menu.AddItem(new GUIContent("Create graph"), false, ContextCallback, "0");
            menu.AddItem(new GUIContent("Load graph"), false, ContextCallback, "1");

            if (editor.curGraph != null)
            {
                menu.AddSeparator("");
                menu.AddItem(new GUIContent("Unload graph"), false, ContextCallback, "2");
            }
            
            menu.ShowAsContext();
            
            e.Use();
        }

        private void ContextCallback(object obj)
        {
            
        }
    }
}