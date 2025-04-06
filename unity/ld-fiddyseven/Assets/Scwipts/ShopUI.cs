using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Button closeButton;
    public Image shopKeeperImage;
    public TextMeshProUGUI shopKeeperTMP;

    private bool isShopOpen = false;

    public void SetIsShopOpen(bool isOpen) { isShopOpen = isOpen; }
    public bool IsShopOpen() { return isShopOpen; }

    public void CloseShop()
    {
        SetIsShopOpen( false );
        Destroy( gameObject );
    }

    private void SetImageFromShopkeeper()
    {
        ShopUISpawner shopkeeper = GetShopUISpawner();
        if (shopkeeper != null)
        {
            shopKeeperImage.sprite = shopkeeper.GetShopkeeperSprite();
            shopKeeperImage.material = shopkeeper.GetShopkeeperMaterial();
        }
    }

    private void SetNameFromShopkeeper()
    {

        ShopUISpawner shopkeeper = GetShopUISpawner();
        if (shopkeeper != null)
        {
            shopKeeperTMP.text = shopkeeper.GetShopkeeperName();
        }
    }

    private ShopUISpawner GetShopUISpawner()
    {
        return GameObject.FindWithTag( "Shopkeeper" ).GetComponent<ShopUISpawner>();
    }

    private void Start()
    {
        SetImageFromShopkeeper();
        SetNameFromShopkeeper();

        if (closeButton != null)
        {
            closeButton.onClick.AddListener( CloseShop );
        }
    }
}