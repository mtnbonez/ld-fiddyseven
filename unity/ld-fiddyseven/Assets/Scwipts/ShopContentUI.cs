using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ShopContentUI : MonoBehaviour
{
    public GameObject itemPrefab; // Assign in Inspector
    public Transform contentPanel; // Assign Scroll View Content Panel

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
        Dictionary<Buff.BUFF_TYPE, BuffData> shopInventory = GetShopInventoryData();

        if (shopInventory == null)
        {
            Debug.Log( "shopInventory is null!" );
            return;
        }

        foreach (BuffData buff in shopInventory.Values)
        {
            GameObject newItem = Instantiate( itemPrefab, contentPanel );

            newItem.transform.Find( "ItemName" ).GetComponent<TMP_Text>().text = buff.buffName;
            newItem.transform.Find( "ItemPrice" ).GetComponent<TMP_Text>().text = $"{buff.buffCost}G";

            Button buyButton = newItem.transform.Find( "BuyButton" ).GetComponent<Button>();
            buyButton.onClick.AddListener( () => PurchaseItem( newItem ) );
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate( contentPanel.GetComponent<RectTransform>() );
    }

    void PurchaseItem( GameObject item )
    {
        Destroy( item );
    }
}