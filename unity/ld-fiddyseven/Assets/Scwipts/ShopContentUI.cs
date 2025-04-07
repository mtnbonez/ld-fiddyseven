using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopContentUI : MonoBehaviour
{
    public GameObject itemPrefab; // Assign in Inspector
    public Transform contentPanel; // Assign Scroll View Content Panel
    public Dictionary<Buff.BUFF_ID, BuffContent> shopInventory;

    private void Start()
    {
        PopulateShop();
    }

    private Dictionary<Buff.BUFF_ID, BuffContent> GetShopInventoryData()
    {
        GameObject shopKeeper = GameObject.FindWithTag( "Shopkeeper" );
        ShopInventory shopInventory = shopKeeper.GetComponentInChildren<ShopInventory>();

        if (shopInventory != null)
        {
            return shopInventory.GetBuffInventoryData();
        }

        return null;
    }

    void PopulateShop()
    {
        shopInventory = GetShopInventoryData();

        if (shopInventory == null)
        {
            Debug.Log( "shopInventory is null!" );
            return;
        }

        foreach ((Buff.BUFF_ID buffId, BuffContent buffContent) in shopInventory)
        {
            GameObject newItem = Instantiate(itemPrefab, contentPanel);

            ShopItem item = newItem.GetComponent<ShopItem>();

            item.SetBuffs(buffContent.buffs);
            item.SetItemName(buffContent.name);
            item.SetItemPrice(buffContent.buffCost);

            Button buyButton = newItem.transform.Find("BuyButton").GetComponent<Button>();
            buyButton.onClick.AddListener(() => PurchaseItem(newItem, buffId, buffContent));
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate( contentPanel.GetComponent<RectTransform>() );
    }

    void PurchaseItem( GameObject item, Buff.BUFF_ID buffId, BuffContent buffContent)
    {
        if (GameManager.Instance.gold < buffContent.buffCost)
        {
            return;
        }

        BuffManager buffManager = GameManager.Instance.GetBuffManager();

        buffManager.AddBuffs(buffContent.buffs);
        shopInventory.Remove(buffId);
        GameManager.Instance.GetStatsManager().AddGoldSpent( buffContent.buffCost );
        Destroy( item );
    }
}