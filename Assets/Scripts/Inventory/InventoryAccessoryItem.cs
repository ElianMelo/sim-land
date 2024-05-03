using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAccessoryItem : MonoBehaviour
{

    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI price;
    [SerializeField]
    private GameObject equipButtonObject;
    [SerializeField]
    private AccessorySO accessorySO;

    private InventoryAccessoryBoard accessoryBoard;

    private Button equipButton;
    private TextMeshProUGUI equipButtonText;

    private void Start()
    {
        equipButton = equipButtonObject.GetComponent<Button>();
        equipButtonText = equipButtonObject.GetComponentInChildren<TextMeshProUGUI>();

        //if(accessorySO.equipped)
        //{
        //    if(accessorySO.type == BodyPartType.CLOTHES)
        //    {
        //        equipButtonText.text = "Equipped";
        //    } else
        //    {
        //        equipButtonText.text = "Unequip";
        //    }
        //}

        LoadAccessorySOData(accessorySO);
    }

    public void SetAccessoryBoard(InventoryAccessoryBoard accessoryBoard)
    {
        this.accessoryBoard = accessoryBoard;
    }

    public void LoadAccessorySOData(AccessorySO accessorySO)
    {
        this.accessorySO = accessorySO;
        icon.sprite = accessorySO.icon;
        title.text = accessorySO.title;
        price.text = "$" + accessorySO.price;
    }

    public void EquipAccessory()
    {
        accessoryBoard.EquipAccessory(accessorySO);
    }
}
