using UnityEngine;

public class PersistObject : MonoBehaviour 
{
    public static PersistObject instance;

    void Awake() 
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } 
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
