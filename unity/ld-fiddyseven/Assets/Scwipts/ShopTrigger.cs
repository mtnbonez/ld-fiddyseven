using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopPrompt;

    private void Start()
    {
        shopPrompt.SetActive( false );
    }

    private void OnTriggerEnter(Collider collision )
    {
        if (collision.CompareTag( "Player" ))
        {
            shopPrompt.SetActive( true );
        }
    }

    private void OnTriggerExit( Collider collision )
    {
        if (collision.CompareTag( "Player" ))
        {
            shopPrompt.SetActive( false );
        }
    }
}
