using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace yuxuetian
{
    public class CustomShortcutKeys
    {
        //在Unity中，使用MenuItem特性定义的快捷键菜单项，加入下划线表示该按键没有组合，直接使用F10
        [MenuItem("ArtTools/ShortKeys/播放 _F10" , false , 501)]
        static void EditorPlayCommand()
        {
            EditorApplication.isPlaying = !EditorApplication.isPlaying;
        }
        
        [MenuItem("ArtTools/ShortKeys/暂停 _F12" ,false , 502)]
        static void EditorPauseCommand()
        {
            EditorApplication.isPaused = !EditorApplication.isPaused;
        }
        
        [MenuItem("ArtTools/ShortKeys/ProjectSetting &1" ,false , 520)]
        static void OpenProjectSettings()
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings...");
        }
        
        [MenuItem("ArtTools/ShortKeys/Preferences &2" , false , 521)]
        static void OpenPreferences()
        {
            EditorApplication.ExecuteMenuItem("Edit/Preferences...");
        }

        private static MethodInfo clearMethod;
        [MenuItem("ArtTools/ShortKeys/清空日志 &3" ,false , 522)]
        static void ClearConsole()
        {
            if (clearMethod == null)
            {
                Type log = typeof(EditorWindow).Assembly.GetType("UnityEditor.LogEntries");
                clearMethod = log.GetMethod("Clear");
            }
            clearMethod.Invoke(null, null);
        }

        [MenuItem("ArtTools/ShortKeys/重置Position #1" , false , 540)]
        static void ResetPosition()
        {
            var positionArray = Selection.transforms;
            if(positionArray == null) return;
            foreach (var pos in positionArray)
            {
                Undo.RecordObject(pos , "Reset Position");
                pos.localPosition = Vector3.zero;
            }
        }
        
        [MenuItem("ArtTools/ShortKeys/重置Rotation #2",false , 541)]
        static void ResetRotation()
        {
            Transform[] rotationArray = Selection.transforms;
            if (rotationArray.Length == 0) return;
            
            foreach (var rot in rotationArray)
            {
                Undo.RecordObject(rot , "Reset Rotation");
                rot.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }
        
        [MenuItem("ArtTools/ShortKeys/重置Scale #3",false , 542)]
        static void ResetScale()
        {
            Transform[] scaleArray = Selection.transforms;
            if (scaleArray.Length == 0) return;
            
            foreach (var scale in scaleArray)
            {
                Undo.RecordObject(scale , "Reset Rotation");
                scale.localScale = Vector3.one;
            }
            
        }
    }
}
