﻿using System;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using MemoryPack;
namespace TaoTie
{
    public abstract class BaseEditorWindow<T> : OdinEditorWindow where T : class
    {
        protected virtual string fileName => TypeInfo<T>.Name;
        protected virtual string folderPath => "Assets/AssetsPackage";
        private bool isJson;

        public void Init(T data, string searchPath, bool isJson)
        {
            this.data = data;
            filePath = searchPath;
            this.isJson = isJson;
        }

        protected virtual T CreateInstance()
        {
            return Activator.CreateInstance<T>();
        }


        [ShowIf("@data!=null")] [ReadOnly] public string filePath;
        [ShowIf("@data!=null")] public T data;

        #region Create

        [Button("打开")]
        public void Open()
        {
            string searchPath = EditorUtility.OpenFilePanel($"选择{typeof(T).Name}配置文件", folderPath, "bytes|json");
            if (!string.IsNullOrEmpty(searchPath))
            {
                var text = File.ReadAllText(searchPath);
                try
                {
                    data = JsonHelper.FromJson<T>(text);
                    filePath = searchPath;
                    isJson = true;
                    return;
                }
                catch (Exception ex)
                {
                }

                var bytes = File.ReadAllBytes(searchPath);
                try
                {
                    data = MemoryPackSerializer.Deserialize<T>(bytes);
                    filePath = searchPath;
                    isJson = false;
                    return;
                }
                catch (Exception ex)
                {
                }

                data = null;
                filePath = null;
                ShowNotification(new GUIContent($"非{typeof(T).Name}文件或内容损坏"));
            }
        }

        [Button("新建(Json)")]
        public void CreateJson()
        {
            string searchPath = EditorUtility.SaveFilePanel($"新建{typeof(T).Name}配置文件", folderPath, fileName, "bytes");
            if (!string.IsNullOrEmpty(searchPath))
            {
                isJson = true;
                data = CreateInstance();
                filePath = searchPath;
                var jStr = JsonHelper.ToJson(data);
                File.WriteAllText(filePath, jStr);
                AssetDatabase.Refresh();
            }
        }

        [Button("新建(二进制)")]
        public void CreateBytes()
        {
            string searchPath = EditorUtility.SaveFilePanel($"选择{typeof(T).Name}配置文件", folderPath, fileName, "bytes");
            if (!string.IsNullOrEmpty(searchPath))
            {
                isJson = false;
                data = CreateInstance();
                filePath = searchPath;
                var bytes = MemoryPackSerializer.Serialize(data);
                File.WriteAllBytes(filePath, bytes);
                AssetDatabase.Refresh();
            }
        }

        #endregion

        #region Save

        [Button("保存(Json)")]
        [ShowIf("@data!=null&&isJson")]
        public void SaveJson()
        {
            if (data != null && !string.IsNullOrEmpty(filePath))
            {
                var jStr = JsonHelper.ToJson(data);
                File.WriteAllText(filePath, jStr);
                AssetDatabase.Refresh();
                ShowNotification(new GUIContent("保存Json成功"));
            }
        }

        [Button("保存(二进制)")]
        [ShowIf("@data!=null&&!isJson")]
        public void SaveBytes()
        {
            if (data != null && !string.IsNullOrEmpty(filePath))
            {
                var bytes = MemoryPackSerializer.Serialize(data);
                File.WriteAllBytes(filePath, bytes);
                AssetDatabase.Refresh();
                ShowNotification(new GUIContent("保存二进制成功"));
            }
        }

        [Button("另存为(Json)")]
        [ShowIf("@data!=null&&!isJson")]
        public void SaveNewJson()
        {
            var names = filePath.Split('/', '.');
            string searchPath = EditorUtility.SaveFilePanel($"新建{typeof(T).Name}配置文件", folderPath, names[names.Length-2], "json");
            if (!string.IsNullOrEmpty(searchPath))
            {
                isJson = true;
                filePath = searchPath;
                var jStr = JsonHelper.ToJson(data);
                File.WriteAllText(filePath, jStr);
                AssetDatabase.Refresh();
            }
        }

        [Button("另存为(二进制)")]
        [ShowIf("@data!=null&&isJson")]
        public void SaveNewBytes()
        {
            var names = filePath.Split('/', '.');
            string searchPath = EditorUtility.SaveFilePanel($"选择{typeof(T).Name}配置文件", folderPath, names[names.Length-2], "bytes");
            if (!string.IsNullOrEmpty(searchPath))
            {
                isJson = false;
                filePath = searchPath;
                var bytes = MemoryPackSerializer.Serialize(data);
                File.WriteAllBytes(filePath, bytes);
                AssetDatabase.Refresh();
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (data != null)
            {
                var res = EditorUtility.DisplayDialog("提示", "是否需要保存？", "是", "否");
                if (res)
                {
                    if (isJson)
                    {
                        SaveJson();
                    }
                    else
                    {
                        SaveBytes();
                    }
                }
            }
        }
        #endregion
    }
}