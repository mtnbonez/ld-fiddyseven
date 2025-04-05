using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameManager _gm;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            _gm.SwitchScene_MainMenu();
        }
    }
}
