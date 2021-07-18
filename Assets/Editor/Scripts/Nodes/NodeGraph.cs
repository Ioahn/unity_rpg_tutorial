using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor.Scripts.Nodes
{
    [Serializable]
    public class NodeGraph: ScriptableObject
    {
        public string graphName = "New Graph";
        public List<NodeBase> nodes;


        private void OnEnable()
        {
            if (nodes == null)
            {
                nodes = new List<NodeBase>();
            }
        }

        public void InitGraph()
        {
            nodes.ForEach(node =>
            {
                node.InitNode();    
            });    
        }

        public void UpdateGraph()
        {
            EditorUtility.SetDirty(this);
        }

        void ProcessEvents()
        {
            
        }
    }
}