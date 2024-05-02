using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryItem : MonoBehaviour
{
    [SerializeField]
    private Image picture;
    [SerializeField]
    private TextMeshProUGUI description;
    [SerializeField]
    private TextMeshProUGUI reward;
    [SerializeField]
    private TextMeshProUGUI amount;
    [SerializeField]
    private Image item;
    [SerializeField]
    private AccessorySO accessorySO;

    // private ItemSO itemSO;
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
        //itemSO = accessorySO.item;
        picture.sprite = accessorySO.picture;
        //item.sprite = itemSO.image;
        description.text = accessorySO.description;
        reward.text = "Reward: $" + accessorySO.reward;
        UpdateAccessoryAmount();
    }

    private void OnEnable()
    {
        UpdateAccessoryAmount();
    }

    public void UpdateAccessoryAmount()
    {
        //if (!itemSO) return;
        //amount.text = ItemManager.Instance.GetAmountByItemSO(itemSO) + " / " + accessorySO.amount;
    }

    public void CompleteAccessory()
    {
        //if (ItemManager.Instance.GetAmountByItemSO(itemSO) >= accessorySO.amount)
        //{
        //    ItemManager.Instance.RemoveItemSO(itemSO, true, accessorySO.amount);
        //    MoneyManager.Instance.AddAmount(accessorySO.reward);
        //    accessoryBoard.RemoveAccessory(gameObject);
        //}
    }
}
