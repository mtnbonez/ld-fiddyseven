using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    public GameObject itemPrefab; // Assign in Inspector
    public Transform contentPanel; // Assign Scroll View Content Panel

    private Dictionary<string, int> shopInventory = new Dictionary<string, int>
    {
        {"Pickaxe Damage", 100 },
        {"Pickaxe Speed", 100 },
        {"Probably something cool", 500 },
        {"I'll never tell", 5000 },
    };

    private void Start()
    {
        PopulateShop();
    }

    void PopulateShop()
    {
        // Sample shop items
        foreach (var item in shopInventory)
        {
            GameObject newItem = Instantiate( itemPrefab, contentPanel );

            newItem.transform.Find( "ItemName" ).GetComponent<TMP_Text>().text = item.Key;
            newItem.transform.Find( "ItemPrice" ).GetComponent<TMP_Text>().text = $"{item.Value}G";

            Button buyButton = newItem.transform.Find( "BuyButton" ).GetComponent<Button>();
            buyButton.onClick.AddListener( () => PurchaseItem( newItem ) );
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate( contentPanel.GetComponent<RectTransform>() );
    }

    void PurchaseItem( GameObject item )
    {
        Destroy( item ); // Removes the item from the list
    }
}