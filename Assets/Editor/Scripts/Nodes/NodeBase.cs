using System;
using UnityEngine;

namespace Editor.Scripts.Nodes
{
    [Serializable]
    public class NodeBase: ScriptableObject
    {
        public string nodeName;
        public Rect nodeRect;
        public NodeGraph parentGraph;

        protected GUISkin nodeSkin;

        
        public virtual void InitNode()
        {
            
        }

        public virtual void UpdateNode()
        {
            UpdateNodeGUI();

            HandlersUpdate();
        }

        private void HandlersUpdate()
        {
            ProcessEvents(Event.current);
        }

        public virtual void UpdateNodeGUI()
        {
            
        }

        public virtual void ProcessEvents(Event e)
        {
            
        }
    }
}