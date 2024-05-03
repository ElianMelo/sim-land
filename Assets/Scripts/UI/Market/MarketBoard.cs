using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketBoard : MonoBehaviour
{
    [SerializeField]
    private AccessoryBoard board;

    private Merchant merchant;

    public void SetMerchant(Merchant newMerchant)
    {
        merchant = newMerchant;
    }

    public void CloseMarket()
    {
        InterfaceManager.Instance.CloseMarket();
    }

    public void SetupMarketBoardBuy()
    {
        board.ChangeMarketState(MarketType.BUY);
        board.ChangeItemsList(merchant.GetItems());
        InterfaceManager.Instance.OpenMarket();
    }

    public void SetupMarketBoardSell()
    {
        board.ChangeMarketState(MarketType.SELL);
        board.ChangeItemsList(InventoryManager.Instance.GetAccessories());
        InterfaceManager.Instance.OpenMarket();
    }
}
