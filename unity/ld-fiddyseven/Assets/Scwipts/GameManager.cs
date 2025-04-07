using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;

    [SerializeField] AudioSource ambientSfx;

    // Put stats & buffs here!
    private BuffManager buffManager;
    private StatsManager statsManager;

    // Here's an example - follow this
    public int LevelCompleted = 0;
    public int gold = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        buffManager = new BuffManager();
        statsManager = new StatsManager();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public BuffManager GetBuffManager()
    {
        return buffManager;
    }

    public StatsManager GetStatsManager()
    {
        return statsManager;
    }

    public void SwitchScene_MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SwitchScene_Shop()
    {
        SceneManager.LoadScene(1);
    }

    public void SwitchSceneToIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public int GetNumOfScenes()
    {
        return SceneManager.sceneCountInBuildSettings;
    }
}
