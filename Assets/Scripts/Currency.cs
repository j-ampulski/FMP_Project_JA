using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    public TextMeshProUGUI MoneyUI;

    public int money = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int amount) 
    { 
        money += amount;
        UpdateUI();
    }

    void UpdateUI() 
    {
        MoneyUI.text = "Money: " + money;
    }
}
