using System;
using Editor.Windows;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Editor.Views
{
    [Serializable]
    public class ViewBase {
       
        public string viewTitle;
        public Rect viewRect;
        public NodeEditor editor;

        protected GUISkin viewSkin;

        public ViewBase(string title, NodeEditor editor)
        {
            viewTitle = title;
            this.editor = editor;
            GetEditorSkins();
        }

        public virtual void UpdateView(Rect editorRect, Rect percentageRect)
        {
            GUIUpdate(editorRect, percentageRect);

            HandlerUpdate();
        }

        private void HandlerUpdate()
        {
            ProcessEvents(Event.current);
        }

        private void GUIUpdate(Rect editorRect, Rect precentageRect)
        {
            if (viewSkin == null)
            {
                GetEditorSkins();
            }
            
            viewRect = new Rect(editorRect.x * precentageRect.x,
                editorRect.y * precentageRect.y,
                editorRect.width * precentageRect.width,
                editorRect.height * precentageRect.height);
            
            editor.curGraph?.UpdateGraph();
        }

        public virtual void ProcessEvents(Event e)
        {
        }

        protected void GetEditorSkins()
        {
            viewSkin = Resources.Load<GUISkin>("GUISkins/EditorSkin");
        }

    }
}