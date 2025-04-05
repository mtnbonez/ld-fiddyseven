using UnityEditor.Build;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopPrompt;

    private Player player;

    private void Start()
    {
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
