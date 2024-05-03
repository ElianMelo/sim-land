using System.Collections.Generic;
using UnityEngine;

public class InventoryAccessoryBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject accessoryPrefab;

    [SerializeField]
    private List<AccessorySO> items = new List<AccessorySO>();

    private List<GameObject> accessorys = new List<GameObject>();

    public delegate void ItemEquipped(AccessorySO accessorySO);
    public static event ItemEquipped OnItemEquipped;

    public void ChangeItemsList(List<AccessorySO> newItems)
    {
        items = newItems;

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

    public void AddAccessory(AccessorySO accessorySO)
    {
        var instance = Instantiate(accessoryPrefab);
        instance.transform.SetParent(this.transform);
        instance.GetComponent<InventoryAccessoryItem>().LoadAccessorySOData(accessorySO);
        instance.GetComponent<InventoryAccessoryItem>().SetAccessoryBoard(this);
        instance.GetComponent<RectTransform>().localScale = new Vector3(2f, 2f, 2f);
        accessorys.Add(instance);
    }

    public void RemoveAccessory(GameObject accessory, AccessorySO accessorySO)
    {
        items.Remove(accessorySO);
        accessorys.Remove(accessory);
        Destroy(accessory);
    }

    public void EquipAccessory(AccessorySO accessorySO)
    {
        OnItemEquipped?.Invoke(accessorySO);
    }
}
