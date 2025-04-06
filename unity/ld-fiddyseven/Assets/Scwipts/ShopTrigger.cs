using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShopTrigger : MonoBehaviour
{
    private Player player;

    private void OnTriggerEnter(Collider collision )
    {
        player = collision.GetComponentInParent<Player>();

        if (player != null && player.CompareTag( "Player" ))
        {
            collision.transform.Find( "ShopPromptText" ).gameObject.SetActive(true);
            player.SetCurrentShop( gameObject.transform.root.gameObject );
            UpdatePlayerIsNearShop( player, true );
        }
    }

    private void OnTriggerExit( Collider collision )
    {
        player = collision.GetComponentInParent<Player>();
        Transform uiCanvas = FindFirstObjectByType<Canvas>().transform;

        if (player != null && player.CompareTag( "Player" ))
        {
            collision.transform.Find( "ShopPromptText" ).gameObject.SetActive( false );
            player.SetCurrentShop( null );
            UpdatePlayerIsNearShop( player, false );
        }

        if (uiCanvas != null)
        {
            uiCanvas.GetComponentInChildren<ShopUI>().CloseShop();
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
