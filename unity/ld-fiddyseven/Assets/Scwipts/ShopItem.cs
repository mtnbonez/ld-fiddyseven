using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI itemName;

    [SerializeField]
    TextMeshProUGUI itemPrice;

    private int buffPrice;
    private Color32 youreBroke = new Color32(130, 10, 10, 255);

    Buff.BUFF_TYPE buffType;

    private void OnEnable()
    {
        GameManager.OnGoldAmountChanged += UpdateCostColor;
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

    public void SetBuffType(Buff.BUFF_TYPE buff )
    {
        buffType = buff;
    }

    private void UpdateCostColor(int totalGold)
    {
        if (totalGold < buffPrice)
        {
            itemPrice.color = youreBroke;
        }
    }
}
