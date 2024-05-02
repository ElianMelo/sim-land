using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBoard : MonoBehaviour
{
    [SerializeField]
    private AccessoryBoard board;

    public void CloseInventory()
    {
        InterfaceManager.Instance.CloseInventory();
    }

    private void OnEnable()
    {
        board.ChangeItemsList(InventoryManager.Instance.GetAccessories());
    }


}
