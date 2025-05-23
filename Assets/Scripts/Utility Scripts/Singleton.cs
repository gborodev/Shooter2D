using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance { get; private set; }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            return;
        }
        Destroy(gameObject);
    }
}
