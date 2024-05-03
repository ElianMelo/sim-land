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
        InterfaceManager.Instance.OpenMarket();
        board.ChangeMarketState(MarketState.BUY);
        board.ChangeItemsList(merchant.GetItems());
    }

    public void SetupMarketBoardSell()
    {
        InterfaceManager.Instance.OpenMarket();
        board.ChangeMarketState(MarketState.SELL);
        board.ChangeItemsList(InventoryManager.Instance.GetAccessories());
    }
}
