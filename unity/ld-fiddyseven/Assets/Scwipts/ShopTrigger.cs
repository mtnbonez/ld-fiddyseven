using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShopTrigger : MonoBehaviour
{
    private Player player;

    private void OnTriggerEnter(Collider collision )
    {
        if (!collision.CompareTag( "playerCollision" ))
        {
            return;
        }

        player = collision.GetComponentInParent<Player>();

        if (player != null && player.CompareTag( "Player" ))
        {
            GameObject openShopText = collision.transform.Find( "ShopPromptText" ).gameObject;
            if (openShopText != null)
            {
                openShopText.SetActive( true );
                player.SetCurrentShop( gameObject.transform.root.gameObject );
                UpdatePlayerIsNearShop( player, true );
            }
            
        }
    }

    private void OnTriggerExit( Collider collision )
    {
        if (!collision.CompareTag( "playerCollision" ))
        {
            return;
        }

        player = collision.GetComponentInParent<Player>();
        Transform uiCanvas = FindFirstObjectByType<Canvas>().transform;

        if (player != null && player.CompareTag( "Player" ))
        {
            GameObject openShopText = collision.transform.Find( "ShopPromptText" ).gameObject;
            if (openShopText != null)
            {
                openShopText.SetActive( false );
                player.SetCurrentShop( null );
                UpdatePlayerIsNearShop( player, false );
            }
        }

        if (uiCanvas != null)
        {
            ShopUI shopUI = uiCanvas.GetComponentInChildren<ShopUI>();
            if (shopUI != null)
            {
                shopUI.CloseShop();
            }
        } 
    }

    private void UpdatePlayerIsNearShop( Player player, bool isNearShop )
    {
        if (player != null)
        {
            player.SetIsNearShop( isNearShop );
        }
    }
}
