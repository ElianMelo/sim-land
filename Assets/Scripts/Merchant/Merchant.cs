using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject dialogTextUI;
    private bool canTriggerMarket = false;

    [SerializeField]
    private List<AccessorySO> items = new List<AccessorySO>();

    private void Update()
    {
        if (canTriggerMarket && Input.GetKeyDown(KeyCode.E))
        {
            canTriggerMarket = false;
            dialogTextUI.SetActive(false);
            InterfaceManager.Instance.OpenMarketChoice(this);
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

    public void AddItem(AccessorySO accessorySO)
    {
        items.Add(accessorySO);
    }

    public void ClearItems()
    {
        items.Clear();
    }

    public List<AccessorySO> GetItems()
    {
        return items;
    }
}
