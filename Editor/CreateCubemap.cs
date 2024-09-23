using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian
{
    public class CreateCubemap : ScriptableWizard
    {
        [Tooltip("选择一个渲染Cubemap的物体位置")]
        public Transform renderFromPosition;
        [Tooltip("选择一个将环境渲染到的目标，这里的目标是一个cubemap纹理")]
        public Cubemap cubemap;     //在Create下的Legacy下创建cubemap文件
        
        [MenuItem("ArtTools/RenderToCubemap")]
        static void RenderCubemap()
        {
            //"Create Cubemap"是打开的窗口名，"Create"是按钮名，点击时调用OnWizardCreate()方法
            ScriptableWizard.DisplayWizard<CreateCubemap>("RenderCubemap", "Render");
        }

        private void OnWizardUpdate()
        {
            helpString = "选择渲染位置并且确定需要设置的cubemap";
            bool isVaild = (renderFromPosition != null) && (cubemap != null);
        }

        private void OnWizardCreate()
        {
            GameObject go = new GameObject("CubemapCamera");
            go.AddComponent<Camera>();
            go.transform.position = renderFromPosition.position;
            go.GetComponent<Camera>().RenderToCubemap(cubemap); //用户提供的Cubemap传递给RenderToCubemap函数，生成六张图片
            
            DestroyImmediate(go);   //销毁创建的临时相机
        }
    }
}
