using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketBoard : MonoBehaviour
{
    public void CloseMarket()
    {
        InterfaceManager.Instance.CloseMarket();
    }
}
