using UnityEngine;

public class ShopIntroHandler : MonoBehaviour
{
    public GameObject dialogBox;
    public bool HideAfterExit = false;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "playerCollision" && !hasTriggered)
        {
            if (dialogBox != null)
            {
                dialogBox.SetActive(true);
            }

            hasTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (HideAfterExit)
        {
            if (other.tag == "playerCollision" && hasTriggered)
            {
                if (dialogBox != null)
                {
                    dialogBox.SetActive(false);
                }
            }
        }
    }
}
