using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject dialogTextUI;
    private bool canTriggerDialog = false;

    private void Update()
    {
        if (canTriggerDialog && Input.GetKeyDown(KeyCode.E))
        {
            canTriggerDialog = false;
            dialogTextUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTriggerDialog = true;
        dialogTextUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTriggerDialog = false;
        dialogTextUI.SetActive(false);
    }
}
