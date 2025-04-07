using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopContentUI : MonoBehaviour
{
    public GameObject itemPrefab; // Assign in Inspector
    public Transform contentPanel; // Assign Scroll View Content Panel
    public Dictionary<Buff.BUFF_TYPE, BuffData> shopInventory;

    private void Start()
    {
        PopulateShop();
    }

    private Dictionary<Buff.BUFF_TYPE, BuffData> GetShopInventoryData()
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

        foreach (BuffData buff in shopInventory.Values)
        {
            GameObject newItem = Instantiate( itemPrefab, contentPanel );

            ShopItem item = newItem.GetComponent<ShopItem>();

            item.SetBuffType( buff.buffType );
            item.SetItemName( buff.buffName );
            item.SetItemPrice( buff.buffCost );

            Button buyButton = newItem.transform.Find( "BuyButton" ).GetComponent<Button>();
            buyButton.onClick.AddListener( () => PurchaseItem( newItem, buff ) );
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate( contentPanel.GetComponent<RectTransform>() );
    }

    void PurchaseItem( GameObject item, BuffData buffData )
    {
        // TODO: Logic for buying buffs with currency

        BuffManager buffManager = GameManager.Instance.GetBuffManager();
        buffManager.AddBuff( buffData.buffType );
        shopInventory.Remove( buffData.buffType );

        Destroy( item );
    }
}