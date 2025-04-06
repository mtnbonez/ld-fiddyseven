using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShopTrigger : MonoBehaviour
{
    private GameObject shopPrompt;
    private Player player;

    private void Start()
    {
        player = GameObject.FindWithTag( "Player" ).GetComponent<Player>();

        if ( player != null)
        {
            Transform character = player.transform.Find( "Character" );

            if ( character != null)
            {
                shopPrompt = character.GetComponentInChildren<Transform>().Find( "ShopPromptText" )?.gameObject;
                shopPrompt.SetActive( false );
            }
        }
    }

    private void OnTriggerEnter(Collider collision )
    {
        player = collision.GetComponentInParent<Player>();

        if (player != null && player.CompareTag( "Player" ))
        {
            shopPrompt.SetActive( true );
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
            shopPrompt.SetActive( false );
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
