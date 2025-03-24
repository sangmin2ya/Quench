using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    private static JsonReader _instance;
    public static JsonReader Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject JsonReaderObject = new GameObject("JsonReader");
                _instance = JsonReaderObject.AddComponent<JsonReader>();

                DontDestroyOnLoad(JsonReaderObject);
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);

            Initialize();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public ItemDB itemDB;

    // Start is called before the first frame update
    private void Initialize()
    {
        TextAsset itemJson = Resources.Load<TextAsset>("Json/Item");
        print(itemJson.text);
        itemDB = JsonUtility.FromJson<ItemDB>(itemJson.text);
        foreach (var item in itemDB.items)
        {
            print(item.itemName);
        }
    }
}

[Serializable]
public class ItemDB
{
    public Item[] items;
}
