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
    [SerializeField]
    private GameObject buyButton;
    [SerializeField]
    private GameObject sellButton;

    private AccessoryBoard accessoryBoard;

    private void Start()
    {
        LoadAccessorySOData(accessorySO);
    }

    public void SetAccessoryBoard(AccessoryBoard accessoryBoard)
    {
        this.accessoryBoard = accessoryBoard;
    }

    public void SetMarketType(MarketType marketType)
    {
        switch (marketType)
        {
            case MarketType.BUY:
                buyButton.SetActive(true);
                sellButton.SetActive(false);
                break;
            case MarketType.SELL:
                sellButton.SetActive(true);
                buyButton.SetActive(false);
                break;
        }
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
