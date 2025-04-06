using UnityEngine;
using UnityEngine.UI;
public class WinTrigger : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.LevelCompleted += 1;
        GameManager.Instance.SwitchScene_Shop();
    } 

}

