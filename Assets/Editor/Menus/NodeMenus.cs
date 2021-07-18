using Editor.Windows;
using UnityEditor;

namespace Editor.Menus
{
    public static class NodeMenus
    {
        [MenuItem("Node Editor/Launch Editor")]
        public static void InitNodeEditor()
        {
            NodeEditor.InitNodeEditor();        
        }
    }
}