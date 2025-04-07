using UnityEngine;
using System.Collections;

public class IntroPlayerAnimation : MonoBehaviour
{

    [SerializeField] public bool firstboot = false;
    [SerializeField] public float CameraDelay = 0f;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Canvas PlayerUICanvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (firstboot)
        {
            PlayerCamera.enabled = false;
            if (PlayerUICanvas != null)
            {
                PlayerUICanvas.enabled = false;
            }
            StartCoroutine(ActivateCam(CameraDelay));
        }
    }
    IEnumerator ActivateCam(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        PlayerCamera.enabled = true;
        if (TryGetComponent<Player>(out Player MyPlayer))
        {
           MyPlayer.UpdatePlayerInputEnabled();
        }
        if (PlayerUICanvas != null)
        {
            PlayerUICanvas.enabled = true;
        }
    }
}



