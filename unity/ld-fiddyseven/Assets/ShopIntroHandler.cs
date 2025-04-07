using UnityEngine;

public class ShopIntroHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "playerCollision")
        {
            Debug.Log("Test");
            // Enable dialog box
            // TODO: add dialog box as well
            AudioSource audioSource = GetComponentInChildren<AudioSource>();

            if (audioSource != null)
            {
                audioSource.enabled = true;
            }
        }
    }
}
