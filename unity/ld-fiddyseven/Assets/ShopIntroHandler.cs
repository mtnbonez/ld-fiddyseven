using UnityEngine;

public class ShopIntroHandler : MonoBehaviour
{
    public GameObject dialogBox;
<<<<<<< Updated upstream
    public bool HideAfterExit = false;
=======
>>>>>>> Stashed changes

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "playerCollision" && !hasTriggered)
        {
<<<<<<< Updated upstream
=======
            Debug.Log("Test");
            // Enable dialog box
            // TODO: add dialog box as well

>>>>>>> Stashed changes
            if (dialogBox != null)
            {
                dialogBox.SetActive(true);
            }

            hasTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
<<<<<<< Updated upstream
        if (HideAfterExit)
        {
            if (other.tag == "playerCollision" && hasTriggered)
            {
                if (dialogBox != null)
                {
                    dialogBox.SetActive(false);
                }
=======
        if (other.tag == "playerCollision" && hasTriggered)
        {
            Debug.Log("Test2");

            if (dialogBox != null)
            {
                dialogBox.SetActive(false);
>>>>>>> Stashed changes
            }
        }
    }
}
