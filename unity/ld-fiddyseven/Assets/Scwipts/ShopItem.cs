using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI itemName;

    [SerializeField]
    TextMeshProUGUI itemPrice;

    private int buffPrice;
    private Color32 youreBroke = new Color32(130, 10, 10, 255);
    public List<BuffData> buffList = new List<BuffData>();

    private Color32 ogPriceColor;

    private void OnEnable()
    {
        GameManager.OnGoldAmountChanged += UpdateCostColor;
        ogPriceColor = itemPrice.color;
    }

    private void OnDisable()
    {
        GameManager.OnGoldAmountChanged -= UpdateCostColor;
    }

    public void SetItemName(string name )
    {
        itemName.text = name;
    }

    public void SetItemPrice(int price)
    {
        buffPrice = price;
        itemPrice.text = $"{price}G";

        if (GameManager.Instance.gold < price)
        {
            itemPrice.color = youreBroke;
        }
    }

    public void SetBuffs(List<BuffData> buffs)
    {
        buffList = buffs;
    }

    private void UpdateCostColor(int totalGold)
    {
        if (totalGold < buffPrice)
        {
            itemPrice.color = youreBroke;
        }
        else
        {
            itemPrice.color = ogPriceColor;
        }
    }
}
