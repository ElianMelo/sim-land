using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterfaceState
{
    NONE,
    MARKET,
    INVENTORY
}

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager Instance;
    public GameObject marketBoard;
    public GameObject inventoryBoard;

    private InterfaceState currentState = InterfaceState.NONE;

    private void Awake()
    {
        Instance = this;
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
            }
        }
    }

    public void OpenMarket()
    {
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
}
