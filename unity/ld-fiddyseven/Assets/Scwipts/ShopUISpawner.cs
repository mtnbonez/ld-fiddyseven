using UnityEngine;

public class ShopUISpawner : MonoBehaviour
{
    public GameObject shopUIPrefab;
    public GameObject exitDialogBox;
    public AudioSource purchaseSFX;

    [SerializeField]
    private Sprite ShopkeeperSprite;

    [SerializeField]
    private Material ShopkeeperMaterial;

    [SerializeField]
    private string ShopkeeperName;


    private Transform uiCanvas;
    private Player player;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
        uiCanvas = FindFirstObjectByType<Canvas>().transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown( KeyCode.E ))
        {
            if (player.IsNearShop() &&
                uiCanvas != null)
            {
                if (uiCanvas.GetComponentInChildren<ShopUI>() != null &&
                    uiCanvas.GetComponentInChildren<ShopUI>().IsShopOpen())
                {
                    return;
                }
                else
                {
                    player.PlayMmhmm();
                    OpenShop();
                }
            }
        }
    }

    void OpenShop()
    {
        GameObject shopUI = Instantiate( shopUIPrefab, uiCanvas );
        shopUI.transform.SetParent( uiCanvas, false );
        ShopUI shopUiComponent = uiCanvas.GetComponentInChildren<ShopUI>();
        shopUiComponent.Init(exitDialogBox, purchaseSFX);
        shopUiComponent.SetIsShopOpen( true );
        
        if (exitDialogBox != null)
        {
            exitDialogBox.SetActive( false );
        }
    }

    public Sprite GetShopkeeperSprite()
    {
        return ShopkeeperSprite;
    }

    public string GetShopkeeperName()
    {
        return ShopkeeperName;
    }

    public Material GetShopkeeperMaterial()
    {
        return ShopkeeperMaterial;
    }

    public void PlayPurchaseSFX()
    {
        purchaseSFX.Play();
    }
}
