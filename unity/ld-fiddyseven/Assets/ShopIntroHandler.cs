using UnityEngine;

public class ShopIntroHandler : MonoBehaviour
{
    public GameObject dialogBox;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "playerCollision" && !hasTriggered)
        {
            Debug.Log("Test");
            // Enable dialog box
            // TODO: add dialog box as well

            if (dialogBox != null)
            {
                dialogBox.SetActive(true);
            }

            hasTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "playerCollision" && hasTriggered)
        {
            Debug.Log("Test2");

            if (dialogBox != null)
            {
                dialogBox.SetActive(false);
            }
        }
    }
}
