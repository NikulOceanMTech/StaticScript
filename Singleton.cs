using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : class
{
    private static T instance = null;
    private static readonly Object syncRoot = new Object();
    /// <summary>
    /// SingletoneBase instance
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = GameObject.FindObjectOfType(typeof(T)) as T;
                        if (instance == null)
                            Debug.LogError("SingletoneBase<T>: Could not found GameObject of type " + typeof(T).Name);
                    }
                }
            }
            return instance;
        }
    }
}
