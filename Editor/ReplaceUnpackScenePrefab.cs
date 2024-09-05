//用于替换场景中不小心Unpack的预制体物体，通过遍历拖入的新预制体的名称，遍历场景中所有和该名称相似的物体，然后替换成预制体

using UnityEditor;
using UnityEngine;

namespace yuxuetian
{
    public class ReplaceUnpackScenePrefab : EditorWindow
    {
        // 在Inspector中设置这些变量  
        public GameObject replaceGameObject;

        [MenuItem("ArtTools/Model/替换场景中的prefab", false, 103)]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow<ReplaceUnpackScenePrefab>();
            window.titleContent = new GUIContent("替换Prefab");
        }

        public void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("需要替换的prefab:");
            replaceGameObject = EditorGUILayout.ObjectField(replaceGameObject, typeof(GameObject), true) as GameObject;
            GUILayout.EndHorizontal();
            GUILayout.Space(10);

            if (GUILayout.Button("开始执行(手动选择)"))
            {
                //具体执行函数
                ManualReplacePrefabObject();
            }

            GUILayout.Space(20);

            if (GUILayout.Button("开始执行(自动选择)"))
            {
                AutoReplacePrefabObject();
            }
        }

        public void ManualReplacePrefabObject()
        {
            if (replaceGameObject == null)
            {
                Debug.LogError("No Prefab selected to replace with!");
                return;
            }

            GameObject[] gameObjects = Selection.gameObjects;
            for (int i = gameObjects.Length - 1; i >= 0; i--)
            {
                string gameObjectName = gameObjects[i].name.Trim();
                int index = gameObjectName.IndexOf(' ');

                if (index >= 0)
                {
                    gameObjectName = gameObjectName.Substring(0, index);
                }

                if (gameObjectName == replaceGameObject.name || gameObjects[i].name == replaceGameObject.name)
                {
                    // 实例化Prefab  
                    GameObject newObject = PrefabUtility.InstantiatePrefab(replaceGameObject) as GameObject;

                    if (newObject != null)
                    {
                        // 保持原物体的坐标、旋转和缩放  
                        newObject.transform.SetPositionAndRotation(gameObjects[i].transform.position,
                            gameObjects[i].transform.rotation);
                        newObject.transform.localScale = gameObjects[i].transform.localScale;

                        // 设置新物体的父物体（如果需要）  
                        newObject.transform.SetParent(gameObjects[i].transform.parent, false);

                        // 销毁原物体  
                        Undo.DestroyObjectImmediate(gameObjects[i]);

                        // 通知编辑器这个物体已经被替换了（这对于撤销/重做系统很重要）  
                        // Undo.RegisterCreatedObjectUndo(newObject, "Replace " + gameObjects[i].name + " with Prefab");  
                    }
                }
            }

            // 刷新场景视图  
            SceneView.RepaintAll();

            // 输出替换完成的消息  
            Debug.Log("Replacement complete!");
        }

        public void AutoReplacePrefabObject()
        {
            if (replaceGameObject == null)
            {
                Debug.LogError("No Prefab selected to replace with!");
                return;
            }

            // GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
            //FindObjectsOfType<>()已经过时，使用新的方法FindObjectsByType<>()来替换
            FindObjectsSortMode sortMode = FindObjectsSortMode.None;
            GameObject[] gameObjects = GameObject.FindObjectsByType<GameObject>(sortMode);

            for (int i = 0; i < gameObjects.Length; i++)
            {
                //去掉名称前后的空格
                string gameObjectName = gameObjects[i].name.Trim();
                //查找第一个空格的位置
                int index = gameObjectName.IndexOf(' ');

                //如果存在空格
                if (index >= 0)
                {
                    //截取空格之前的部分作为名称
                    gameObjectName = gameObjectName.Substring(0, index);
                }

                //判断名称是否与要替换的Prefab名称一致
                if (gameObjectName == replaceGameObject.name)
                {
                    // 实例化Prefab  
                    GameObject newObject = PrefabUtility.InstantiatePrefab(replaceGameObject) as GameObject;

                    if (newObject != null)
                    {
                        // 保持原物体的坐标、旋转和缩放  
                        newObject.transform.SetPositionAndRotation(gameObjects[i].transform.position,
                            gameObjects[i].transform.rotation);
                        newObject.transform.localScale = gameObjects[i].transform.localScale;

                        // 设置新物体的父物体（如果需要）  
                        newObject.transform.SetParent(gameObjects[i].transform.parent, false);

                        // 销毁原物体  
                        Undo.DestroyObjectImmediate(gameObjects[i]);

                        // 通知编辑器这个物体已经被替换了（这对于撤销/重做系统很重要）  
                        // Undo.RegisterCreatedObjectUndo(newObject, "Replace " + gameObjects[i].name + " with Prefab");  
                    }
                }
            }

            // 刷新场景视图  
            SceneView.RepaintAll();

            // 输出替换完成的消息  
            Debug.Log("Replacement complete!");
        }
    }
}
