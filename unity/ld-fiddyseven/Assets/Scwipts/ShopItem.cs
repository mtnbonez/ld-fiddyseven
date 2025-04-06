using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI itemName;

    [SerializeField]
    TextMeshProUGUI itemPrice;

    Buff.BUFF_TYPE buffType;

    public void SetItemName(string name )
    {
        itemName.text = name;
    }

    public void SetItemPrice(int price)
    {
        itemPrice.text = $"{price}G";
    }

    public void SetBuffType(Buff.BUFF_TYPE buff )
    {
        buffType = buff;
    }
}
