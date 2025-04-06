using UnityEngine;
using System.Collections;

public class IntroPlayerAnimation : MonoBehaviour
{

    [SerializeField] public bool firstboot = false;
    [SerializeField] public float CameraDelay = 0f;
    [SerializeField] private Camera PlayerCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (firstboot)
        {
            PlayerCamera.enabled = false;
            StartCoroutine(ActivateCam(CameraDelay));
        }
    }
    IEnumerator ActivateCam(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        PlayerCamera.enabled = true;
    }
}



