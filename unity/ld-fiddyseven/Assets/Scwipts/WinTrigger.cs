using UnityEngine;
using UnityEngine.UI;
public class WinTrigger : MonoBehaviour
{
    public GameManager _gm;


    public void OnCollisionEnter(Collision collision)
    {
        _gm.SwitchScene_Shop();
    }


 

}

