using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordBase : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Item Type of this item
    /// </summary>
    /// 
    [Header("Item Type")]
    [SerializeField] private ItemType _itemType;
    [SerializeField] private PopUpType _popUpType;

    [Space]

    [Header("Icon Image")]
    [SerializeField] private Sprite _iconImage;

    [Space]

    [Header("Area Name")]
    [TextArea(5, 5)]
    [SerializeField] private string _areaName;

    [Space]

    [Header("Area Description")]
    [TextArea(5, 5)]
    [SerializeField] private string _areaDescription;

    [Space]
    [Header("Area Items")]
    [SerializeField] private List<GameObject> _areaItemObject;

    private List<ItemBase> _areaItems = new List<ItemBase>();

    public ItemType ItemType => _itemType;

    public PopUpType PopUpType => _popUpType;

    private void Awake()
    {
        transform.Find("Check").gameObject.SetActive(false);


        foreach (GameObject item in _areaItemObject)
        {
            _areaItems.Add(item.GetComponent<ItemBase>());
        }
    }

    public virtual void OnHover()
    {
        transform.Find("Check").gameObject.SetActive(true); 
    }

    public virtual void OnHoverExit()
    {

        transform.Find("Check").gameObject.SetActive(false);
    }

    public virtual void OnInteract()
    {
        ScreenManager.Instance.
            EnableListedPopUp(
            _areaName,
            _areaDescription,
            _iconImage,
            _areaItems
            );
    }
}