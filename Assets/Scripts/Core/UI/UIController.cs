using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UIController : Singleton<UIController>
{
    readonly Dictionary<Type, IPresenter> m_presenterMap = new();
    readonly Dictionary<Type, Coroutine> m_coroutineMap = new();

    public async Task<T> OpenAsync<T>(IPrepareData data = null) where T : class, IPresenter, new()
    {
        var type = typeof(T);

        if (m_presenterMap.TryGetValue(type, out var cached))
        {
            cached.OnShow();
            return (T)cached;
        }

        var presenter = new T();
        m_presenterMap[type] = presenter;

        await presenter.LoadAsync(data);
        presenter.OnShow();

        var enumerator = presenter.Run();
        if (enumerator != null)
        {
            m_coroutineMap[type] = StartCoroutine(enumerator);
        }

        return presenter;
    }

    public void Close<T>() where T : class, IPresenter => Close(typeof(T));

    public void Close(Type type)
    {
        if (m_coroutineMap.TryGetValue(type, out var coroutine))
        {
            StopCoroutine(coroutine);
            m_coroutineMap.Remove(type);
        }

        if (m_presenterMap.TryGetValue(type, out var presenter))
        {
            presenter.OnHide();
        }
    }
}
