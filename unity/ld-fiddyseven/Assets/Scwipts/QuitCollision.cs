using UnityEngine;

public class QuitCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("WTF");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
