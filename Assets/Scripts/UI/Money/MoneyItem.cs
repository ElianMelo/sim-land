using TMPro;
using UnityEngine;

public class MoneyItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI amount;

    private void Start()
    {
        MoneyManager.OnMoneyChanged += OnMoneyChanged;
    }

    private void OnDestroy()
    {
        MoneyManager.OnMoneyChanged -= OnMoneyChanged;
    }

    public void OnMoneyChanged()
    {
        amount.text = MoneyManager.Instance.GetAmount().ToString();
    }
}
