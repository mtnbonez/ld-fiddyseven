using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;

    [SerializeField] AudioSource ambientSfx;

    // Put stats & buffs here! 

    // Here's an example - follow this
    public int LevelCompleted = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SwitchScene_MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SwitchScene_Shop()
    {
        SceneManager.LoadScene(1);
    }
}
