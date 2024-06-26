using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField]
    private List<AccessorySO> accessories = new List<AccessorySO>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddAccessory(AccessorySO accessorySO)
    {
        accessories.Add(accessorySO);
    }

    public void RemoveAccessory(AccessorySO accessorySO)
    {
        accessories.Remove(accessorySO);
    }

    public List<AccessorySO> GetAccessories()
    {
        return accessories;
    }
}
