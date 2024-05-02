using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject accessoryPrefab;

    [SerializeField]
    private List<AccessorySO> items = new List<AccessorySO>();

    private List<GameObject> accessorys = new List<GameObject>();

    private void OnEnable()
    {
        foreach (var accessory in accessorys)
        {
            Destroy(accessory);
        }
        accessorys.Clear();
        foreach (AccessorySO accessorySO in items)
        {
            AddAccessory(accessorySO);
        }
    }

    public void ChangeItemsList(List<AccessorySO> newItems)
    {
        items = newItems;
    }

    public void AddAccessory(AccessorySO accessorySO)
    {
        var instance = Instantiate(accessoryPrefab);
        instance.transform.SetParent(this.transform);
        instance.GetComponent<AccessoryItem>().LoadAccessorySOData(accessorySO);
        instance.GetComponent<AccessoryItem>().SetAccessoryBoard(this);
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
}
