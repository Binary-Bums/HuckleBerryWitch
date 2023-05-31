using UnityEngine;
using System.Collections.Generic;

public class PersistObject : MonoBehaviour 
{
    public static PersistObject instance;

    [SerializeField] private List<GameObject> persistentObjects = new List<GameObject>();


    void Start()
    {
        for (int i = 0; i < persistentObjects.Count; i++)
        {
            DontDestroyOnLoad(persistentObjects[i]);
        }
    }
    private void Awake()
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

    public void AddPersistentObject(GameObject obj)
    {
        if (!persistentObjects.Contains(obj))
        {
            DontDestroyOnLoad(obj);
            persistentObjects.Add(obj);
        }
    }

    public void RemovePersistentObject(GameObject obj)
    {
        if (persistentObjects.Contains(obj))
        {
            persistentObjects.Remove(obj);
        }
    }
}
