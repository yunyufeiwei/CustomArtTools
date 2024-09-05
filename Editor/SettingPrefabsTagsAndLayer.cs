using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace yuxuetian
{
    public class SettingPrefabsTagsAndLayer : EditorWindow
    {
        public static string PrefabPaths01 = "Assets/Prefab";
        public TagsType tagSetting = TagsType.Untagged;
        public bool settingTagsProperty = false;
        public bool settingLayersProperty = false;

        //声明一个引擎自带的layer变量，其
        public LayerMask layerSetting;


        [MenuItem("ArtTools/Model/设置预制体层级属性", false, 103)]
        private static void ShowWindow()
        {
            EditorWindow window = GetWindow<SettingPrefabsTagsAndLayer>();
            window.titleContent = new GUIContent("标签层级属性设置");
        }

        public void OnGUI()
        {
            float _width = 150;

            GUILayout.BeginHorizontal();
            GUILayout.Label("指定路径：", EditorStyles.boldLabel);
            PrefabPaths01 =
                GUILayout.TextField(PrefabPaths01, GUILayout.MinWidth(_width),
                    GUILayout.MaxWidth(_width *
                                       4)); //params GUILayoutOption[] options为可选项，该选项里面有一些可额外设置的属性，比如最小和最大的宽度和高度
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            settingTagsProperty = GUILayout.Toggle(settingTagsProperty, "设置标签Tag");
            GUILayout.FlexibleSpace(); //让该行下面的GUI保持右对齐
            tagSetting = (TagsType)EditorGUILayout.EnumPopup(tagSetting);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            settingLayersProperty = GUILayout.Toggle(settingLayersProperty, "设置层级");
            GUILayout.FlexibleSpace(); //让该行下面的GUI保持右对齐
            layerSetting = EditorGUILayout.LayerField(layerSetting);
            GUILayout.EndHorizontal();

            GUILayout.Space(20);

            if (GUILayout.Button("修改预制体设置"))
            {
                FindPrefabsAndSetTags();
            }
        }

        private void FindPrefabsAndSetTags()
        {
            string[] prefabPaths = Directory.GetFiles(PrefabPaths01, "*.prefab", SearchOption.AllDirectories);
            foreach (string path in prefabPaths)
            {
                GameObject prefabObject = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                string customTag = GetTagFromEnum(tagSetting);

                if (settingTagsProperty)
                {
                    prefabObject.tag = customTag;
                }

                if (settingLayersProperty)
                {
                    prefabObject.layer = layerSetting;
                }
            }

            AssetDatabase.SaveAssets();
        }

        public enum TagsType
        {
            Untagged,
            Enemy,
            Break,
            Wall,
            Door,
            PlayerBullet,
            EnemyWeapon,
            EnemyBullet,
            Floor,
            PlayerWeapon,
            PlayerBlock,
            PlayerVehicle,
            EnemyCar,
            PlayerCar,
            Hogwallow,
            Pickup,
            Dizziness,
        }

        private string GetTagFromEnum(TagsType enumValue)
        {
            switch (enumValue)
            {
                case TagsType.Untagged:
                    return "Untagged";
                case TagsType.Enemy:
                    return "Enemy";
                case TagsType.Break:
                    return "Break";
                case TagsType.Wall:
                    return "Wall";
                case TagsType.Door:
                    return "Door";
                case TagsType.PlayerBullet:
                    return "PlayerBullet";
                case TagsType.EnemyWeapon:
                    return "EnemyWeapon";
                case TagsType.EnemyBullet:
                    return "EnemyBullet";
                case TagsType.Floor:
                    return "Floor";
                case TagsType.PlayerWeapon:
                    return "PlayerWeapon";
                case TagsType.PlayerBlock:
                    return "PlayerBlock";
                case TagsType.PlayerVehicle:
                    return "PlayerVehicle";
                case TagsType.EnemyCar:
                    return "EnemyCar";
                case TagsType.PlayerCar:
                    return "PlayerCar";
                case TagsType.Hogwallow:
                    return "Hogwallow";
                case TagsType.Pickup:
                    return "Pickup";
                case TagsType.Dizziness:
                    return "Dizziness";
                default:
                    return string.Empty;
            }
        }
    }
}
