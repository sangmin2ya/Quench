using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject dataManagerObject = new GameObject("DataManager");
                _instance = dataManagerObject.AddComponent<DataManager>();
                DontDestroyOnLoad(dataManagerObject);
            }
            return _instance;
        }
    }
    private float _playerThirst;
    private List<CollectionType> _unCollectedItems = new List<CollectionType>();
    private Vector3 _startPoint;// = new Vector3(-19, -1.5f, 20);
    public bool _goUnderground = false;
    public bool _getGemstone = false;
    private bool _isStarted = false;
    public bool _runInfo = true;
    public bool _reviveInfo = true;
    public float _deathCount = 0;
    public float RotationSpeed = 0.5f;
    public float SoundVolume = 1f;
    private Dictionary<AreaType, HashSet<string>> _keyItems = new Dictionary<AreaType, HashSet<string>>();
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
        _startPoint = new Vector3(-20.5f, -1.5f, 28);
    }
    private void Initialize()
    {
        _playerThirst = 100f;
        _unCollectedItems.AddRange(Enum.GetValues(typeof(CollectionType)).Cast<CollectionType>());
        _unCollectedItems.Remove(CollectionType.None);
    }
    public void GameStarted()
    {
        _isStarted = true;
    }
    public bool IsStarted()
    {
        return _isStarted;
    }
    public void setPlayerThirst(float value)
    {
        _playerThirst = value;
    }
    public float getPlayerThirst()
    {
        return _playerThirst;
    }
    public bool IsCollected(CollectionType type)
    {
        return !_unCollectedItems.Contains(type);
    }
    public void CollectItem(CollectionType type)
    {
        if (_unCollectedItems.Contains(type))
            _unCollectedItems.Remove(type);
    }
    public int GetCollectedCount()
    {
        return Enum.GetValues(typeof(CollectionType)).Cast<CollectionType>().Count() - _unCollectedItems.Count - 1;
    }
    public void GetKeyItem(ItemBase item)
    {
        if (!_keyItems.ContainsKey(item.ItemArea))
        {
            Debug.Log($"{item.ItemArea.ToString()}을 초기화 해..?");
            _keyItems.Add(item.ItemArea, new HashSet<string>());
            _keyItems[item.ItemArea].Add(item.ItemInfo.itemName);
        }
        if (!_keyItems[item.ItemArea].Contains(item.ItemInfo.itemName))
            _keyItems[item.ItemArea].Add(item.ItemInfo.itemName);
    }
    public bool IsKeyItemContained(ItemBase item)
    {
        if (!_keyItems.ContainsKey(item.ItemArea)) return false;
        return _keyItems[item.ItemArea].Contains(item.ItemInfo.itemName);
    }
    public void SetStartPoint(Vector3 startPoint)
    {
        _startPoint = startPoint;
    }
    public Vector3 GetStartPoint()
    {
        return _startPoint;
    }
}