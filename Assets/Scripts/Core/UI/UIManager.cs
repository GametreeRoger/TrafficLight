using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    const string UiPrefabPath = "Prefabs/UI/";

    readonly Dictionary<Type, UIBase> m_uiMap = new Dictionary<Type, UIBase>();
    Canvas m_canvas;

    public void Close<T>() where T : UIBase
    {
        var uiType = typeof(T);

        if (m_uiMap.TryGetValue(uiType, out var ui) && ui != null)
        {
            ui.Hide();
        }
    }

    public T Open<T>() where T : UIBase
    {
        T ui = GetOrCreateUI<T>();

        if (ui != null)
        {
            ui.Show();
        }

        return ui;
    }

    T GetOrCreateUI<T>() where T : UIBase
    {
        Type uiType = typeof(T);

        if (m_uiMap.TryGetValue(uiType, out UIBase cachedUI) && cachedUI != null)
        {
            return cachedUI as T;
        }

        T existingUI = FindAnyObjectByType<T>(FindObjectsInactive.Include);

        if (existingUI != null)
        {
            m_uiMap[uiType] = existingUI;
            return existingUI;
        }

        Canvas canvas = GetCanvas();

        if (canvas == null)
        {
            Debug.LogError("UIManager.Open failed: scene Canvas not found.");
            return null;
        }

        string prefabPath = UiPrefabPath + uiType.Name;
        T prefab = Resources.Load<T>(prefabPath);

        if (prefab == null)
        {
            Debug.LogError($"UIManager.Open failed: Resources/{prefabPath} prefab not found.");
            return null;
        }

        T ui = Instantiate(prefab, canvas.transform);
        ui.gameObject.name = uiType.Name;
        m_uiMap[uiType] = ui;

        return ui;
    }

    Canvas GetCanvas()
    {
        if (m_canvas == null)
        {
            m_canvas = FindAnyObjectByType<Canvas>();
        }

        return m_canvas;
    }
}
