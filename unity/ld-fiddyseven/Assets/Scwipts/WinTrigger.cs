using UnityEngine;
using UnityEngine.UI;
public class WinTrigger : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.TryGetComponent<LavaStripsHandler>(out LavaStripsHandler test))
        {
            GameManager.Instance.LevelCompleted += 1;
            GameManager.Instance.SwitchScene_Shop();
            Debug.Log("Level trigger was hit by " + collision.gameObject.name);
        }

    } 

}

