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

        if ( player == null)
        {
            shopPrompt = player.GetComponentInChildren<Transform>().Find( "ShopPromptText" )?.gameObject;
        }

        shopPrompt.SetActive( false );
    }

    private void OnTriggerEnter(Collider collision )
    {
        if (collision.CompareTag( "Player" ))
        {
            shopPrompt.SetActive( true );
            player = collision.GetComponentInParent<Player>();
            player.SetCurrentShop( gameObject.transform.root.gameObject );
            UpdatePlayerIsNearShop( player, true );
        }
    }

    private void OnTriggerExit( Collider collision )
    {
        if (collision.CompareTag( "Player" ))
        {
            shopPrompt.SetActive( false );
            player = collision.GetComponentInParent<Player>();
            player.SetCurrentShop( null );
            UpdatePlayerIsNearShop( player, false );
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
