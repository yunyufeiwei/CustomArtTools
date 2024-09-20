/*
 * 用于在播放按钮旁边添加一个自定义的按钮显示
 */
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.UIElements;


namespace yuxuetian
{
    // 使用[InitializeOnLoad]属性确保类在Unity编辑器启动时立即加载
    [InitializeOnLoad]
    public class OpenSceneTools
    {
        // 静态构造函数在类被加载时自动调用
        static OpenSceneTools()
        {
            // 在Unity编辑器的左侧工具栏上添加一个自定义的GUI元素
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }
        
        // 自定义的GUI函数，用于绘制工具栏上的按钮
        static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();
            
            var currentScene = EditorSceneManager.GetActiveScene().name;
            
            //设置GUI.Button的按钮宽度
            float width = 30 + currentScene.Length * 8;
            width = Mathf.Clamp(width, 100, 300);
            
            //设置GUI的样式
            var style = new GUIStyle(EditorStyles.toolbarButton);
            //设置GUI中文字的对齐方式
            style.alignment = TextAnchor.MiddleCenter;
            
            //声明一个Icon图标，将其作为按钮的背景图显示
            var sceneIcon = EditorGUIUtility.IconContent("SceneAsset Icon").image;
        
            if (GUILayout.Button(new GUIContent(currentScene, sceneIcon), style, GUILayout.Width(width)))
            {
                // 调用OpenSceneList类中的ShowWindow方法，以显示项目中的所有地图
                OpenSceneList.ShowWindow();
            }
        }
    }
}

