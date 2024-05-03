using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public delegate void MoneyChange();
    public static event MoneyChange OnMoneyChanged;

    private int amount = 5500;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OnMoneyChanged?.Invoke();
    }

    public int GetAmount()
    {
        return amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
        OnMoneyChanged?.Invoke();
    }
    public void RemoveAmount(int value)
    {
        amount -= value;
        OnMoneyChanged?.Invoke();
    }

}
