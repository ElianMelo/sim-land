using System.Collections.Generic;
using UnityEngine;

public enum MarketType
{
    BUY,
    SELL
}

public class AccessoryBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject accessoryPrefab;

    [SerializeField]
    private List<AccessorySO> items = new List<AccessorySO>();

    private List<GameObject> accessorys = new List<GameObject>();

    private List<AccessorySO> selledItems = new List<AccessorySO>();

    private MarketType marketType = MarketType.BUY;

    public void ChangeMarketState(MarketType newMarketType)
    {
        marketType = newMarketType;
    }

    public void ChangeItemsList(List<AccessorySO> newItems)
    {
        items = newItems;
        UpdateItems();
    }

    public void UpdateItems()
    {
        ClearItems();
        AddItems();
        AddSelledItems();
    }

    public void ClearItems()
    {
        foreach (var accessory in accessorys)
        {
            Destroy(accessory);
        }
        accessorys.Clear();
    }

    public void AddItems()
    {
        foreach (AccessorySO accessorySO in items)
        {
            AddAccessory(accessorySO);
        }
    }

    public void AddSelledItems()
    {
        if (marketType == MarketType.BUY)
        {
            foreach (AccessorySO accessorySO in selledItems)
            {
                AddAccessory(accessorySO);
                items.Add(accessorySO);
            }
            selledItems.Clear();
        }
    }

    public void AddAccessory(AccessorySO accessorySO)
    {
        var instance = Instantiate(accessoryPrefab);
        instance.transform.SetParent(this.transform);
        AccessoryItem accessoryItem = instance.GetComponent<AccessoryItem>();
        accessoryItem.LoadAccessorySOData(accessorySO);
        accessoryItem.SetAccessoryBoard(this);
        accessoryItem.SetMarketType(marketType);
        instance.GetComponent<RectTransform>().localScale = new Vector3(2f, 2f, 2f);
        accessorys.Add(instance);
    }

    public void RemoveAccessory(GameObject accessory, AccessorySO accessorySO)
    {
        items.Remove(accessorySO);
        accessorys.Remove(accessory);
        Destroy(accessory);
    }

    public void BuyAccessory(GameObject gameObject, AccessorySO accessorySO)
    {
        MoneyManager.Instance.RemoveAmount(accessorySO.price);
        InventoryManager.Instance.AddAccessory(accessorySO);
        RemoveAccessory(gameObject, accessorySO);
    }

    public void SellAccessory(GameObject gameObject, AccessorySO accessorySO)
    {
        MoneyManager.Instance.AddAmount(accessorySO.price);
        InventoryManager.Instance.RemoveAccessory(accessorySO);
        RemoveAccessory(gameObject, accessorySO);
        selledItems.Add(accessorySO);
    }

}
