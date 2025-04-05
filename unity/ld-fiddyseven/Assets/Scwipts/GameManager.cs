using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public void SwitchScene_MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
