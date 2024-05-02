using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject dialogTextUI;
    private bool canTriggerMarket = false;

    private void Update()
    {
        if (canTriggerMarket && Input.GetKeyDown(KeyCode.E))
        {
            canTriggerMarket = false;
            dialogTextUI.SetActive(false);
            InterfaceManager.Instance.OpenMarket();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTriggerMarket = true;
        dialogTextUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTriggerMarket = false;
        dialogTextUI.SetActive(false);
    }
}
