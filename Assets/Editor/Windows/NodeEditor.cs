using System;
using Editor.Scripts.Nodes;
using Editor.Views;
using UnityEditor;
using UnityEngine;

namespace Editor.Windows
{
    public class NodeEditor : EditorWindow
    {
       

        public static NodeEditor currentWindow;
        public NodeProperty propertyView;
        public NodeWorkflow WorkflowView;

        public NodeGraph curGraph;

        public float viewPercentage = 0.75f;


  
        public static void InitNodeEditor()
        {
            GetCurrentWindow();

            CreateViews();
        }

        private void OnEnable()
        {
           
        }

        private void OnDestroy()
        {
          
        }

        private void Update()
        {
        
        }

        private void OnGUI()
        {
            if (propertyView == null || WorkflowView == null)
            {
                CreateViews();
            }

            WorkflowView?.UpdateView(position, new Rect(0f, 0f, viewPercentage, 1f));
            propertyView?.UpdateView(new Rect(position.width,position.y, position.width, position.height), 
                new Rect(viewPercentage, 0f, 1f - viewPercentage, 1f));
            
            Repaint();
        }
        
        private static void GetCurrentWindow()
        {
            currentWindow = GetWindow<NodeEditor>();
            currentWindow.titleContent.text = "Editor Window";
        }
        
        private static void CreateViews()
        {
            if (currentWindow != null)
            {
                currentWindow.propertyView = new NodeProperty(currentWindow);
                currentWindow.WorkflowView = new NodeWorkflow(currentWindow);
                return;
            }

            GetCurrentWindow();
        }
        


    }
}