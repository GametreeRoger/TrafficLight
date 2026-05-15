using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static T m_instance;
    static bool m_isQuitting;

    public static T Get
    {
        get
        {
            if (m_isQuitting)
            {
                return null;
            }

            if (m_instance != null)
            {
                return m_instance;
            }

            m_instance = FindAnyObjectByType<T>();

            if (m_instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(T).Name);
                m_instance = singletonObject.AddComponent<T>();
                setupInstance(m_instance);
            }

            return m_instance;
        }
    }

    protected virtual void Awake()
    {
        T current = this as T;

        if (m_instance != null && m_instance != current)
        {
            Destroy(gameObject);
            return;
        }

        m_instance = current;
        setupInstance(m_instance);
    }

    protected virtual void OnApplicationQuit()
    {
        m_isQuitting = true;
    }

    static void setupInstance(T instance)
    {
        if (instance == null)
        {
            return;
        }

        GameObject instanceObject = instance.gameObject;
        instanceObject.name = typeof(T).Name;

        if (instanceObject.transform.parent != null)
        {
            instanceObject.transform.SetParent(null);
        }

        DontDestroyOnLoad(instanceObject);
    }
}
