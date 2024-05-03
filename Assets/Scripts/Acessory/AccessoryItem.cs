using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryItem : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI price;
    [SerializeField]
    private AccessorySO accessorySO;

    private AccessoryBoard accessoryBoard;

    private void Start()
    {
        LoadAccessorySOData(accessorySO);
    }

    public void SetAccessoryBoard(AccessoryBoard accessoryBoard)
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

    public void BuyAccessory()
    {
        if(MoneyManager.Instance.GetAmount() >= accessorySO.price)
        {
            accessoryBoard.BuyAccessory(gameObject, accessorySO);
        }
    }

    public void SellAccessory()
    {
        accessoryBoard.SellAccessory(gameObject, accessorySO);
    }
}
