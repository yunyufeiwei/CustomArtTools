using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace yuxuetian
{
    public class CustomCreateAsset
    {
        //实例化模型
        static void CustomInstanceModel(string path)
        {
            var assetObj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            GameObject go = PrefabUtility.InstantiatePrefab(assetObj) as GameObject;
            PrefabUtility.ReplacePrefabAssetOfPrefabInstance(go,assetObj,InteractionMode.AutomatedAction);
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/BunnyLow", false, 140)]
        static void CreateBunnyLow()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/Common/BunnyLow.obj");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/dragon", false, 141)]
        static void CreateDragon()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/Common/dragon.obj");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/Knot", false, 142)]
        static void CreateKnot()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/Common/Knot.FBX");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/Teapot", false, 143)]
        static void CreateTeapot()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/Common/sphere1.obj");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/MatSphere01", false, 144)]
        static void CreateMatSphere01()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/Common/sphere1.obj");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/MatSphere02", false, 145)]
        static void CreateMatSphere02()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/Common/sphere2.FBX");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/DamagedHelmet", false, 146)]
        static void CreateDamagedHelmet()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/DamagedHelmet/DamagedHelmet.fbx");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/Omega", false, 147)]
        static void CreateOmega()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/FortniteOmega/Omega.prefab");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/Head", false, 148)]
        static void CreateHead()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/Head/Head.prefab");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/Jan", false, 149)]
        static void CreateJan()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/Jan/Jan_Fight_Idle.prefab");
        }
        
        [MenuItem("ArtTools/Model/RenderingModel/RobotKyle", false, 150)]
        static void CreateRobotKyle()
        {
            CustomInstanceModel("Packages/com.yuxuetian.arttools/ArtRes/Model/RobotKyle/RobotKyle.prefab");
        }
        
        
    }
}