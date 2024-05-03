using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterfaceState
{
    NONE,
    MARKET,
    INVENTORY,
    TUTORIAL
}

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager Instance;
    [SerializeField]
    private GameObject marketBoard;
    [SerializeField]
    private GameObject inventoryBoard;
    [SerializeField]
    private GameObject choiceBuyOrSell;
    [SerializeField]
    private GameObject tutorial;

    private InterfaceState currentState = InterfaceState.TUTORIAL;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        tutorial.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            switch (currentState)
            {
                case InterfaceState.MARKET:
                    CloseMarket();
                    break;
                case InterfaceState.INVENTORY:
                    CloseInventory();
                    break;
                case InterfaceState.TUTORIAL:
                    CloseTutorial();
                    break;
            }
        }
    }

    public void OpenMarketChoice(Merchant merchant)
    {
        choiceBuyOrSell.SetActive(true);
        marketBoard.GetComponent<MarketBoard>().SetMerchant(merchant);
        GameManager.Instance.PauseGame();
        currentState = InterfaceState.MARKET;
    }

    public void OpenMarket()
    {
        choiceBuyOrSell.SetActive(false);
        marketBoard.SetActive(true);
        GameManager.Instance.PauseGame();
        currentState = InterfaceState.MARKET;
    }

    public void CloseMarket()
    {
        marketBoard.SetActive(false);
        GameManager.Instance.ResumeGame();
        currentState = InterfaceState.NONE;
    }

    public void OpenInventory()
    {
        inventoryBoard.SetActive(true);
        GameManager.Instance.PauseGame();
        currentState = InterfaceState.INVENTORY;
    }

    public void CloseInventory()
    {
        inventoryBoard.SetActive(false);
        GameManager.Instance.ResumeGame();
        currentState = InterfaceState.NONE;
    }

    public void CloseTutorial()
    {
        tutorial.SetActive(false);
        GameManager.Instance.ResumeGame();
        currentState = InterfaceState.NONE;
    }
}
