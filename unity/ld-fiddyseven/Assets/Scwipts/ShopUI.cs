using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Button closeButton;

    private bool isShopOpen = false;

    public void SetIsShopOpen(bool isOpen) { isShopOpen = isOpen; }
    public bool IsShopOpen() { return isShopOpen; }

    private void Start()
    {
        if (closeButton != null)
        {
            closeButton.onClick.AddListener( CloseShop );
        }
    }

    private void CloseShop()
    {
        SetIsShopOpen( false );
        Destroy( gameObject );
    }
}