using UnityEngine;

public class ShopUISpawner : MonoBehaviour
{
    public GameObject shopUIPrefab;

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
        uiCanvas.GetComponentInChildren<ShopUI>().SetIsShopOpen( true );
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
}
