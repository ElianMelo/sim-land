using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager Instance;
    public GameObject marketBoard;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMarket()
    {
        marketBoard.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void CloseMarket()
    {
        marketBoard.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}
