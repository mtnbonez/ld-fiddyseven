using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Buff;

public class GameManager : MonoBehaviour 
{
    // Gold earned/spent events
    public static event Action<int> OnGoldEarned;
    public static event Action<int> OnGoldSpent;
    public static event Action<int> OnGoldAmountChanged;

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
        SceneManager.activeSceneChanged += OnActiveSceneChange;

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnActiveSceneChange(Scene previousScene, Scene newScene)
    {
        // If we return to the MainMenu scene, clear all buffs
        if (newScene.buildIndex == 0)
        {
            buffManager.ClearAllBuffs();
        }
    }

    public BuffManager GetBuffManager()
    {
        return buffManager;
    }

    public float GetSpeedBuffMultiplier()
    {
        BuffData data = buffManager.GetActiveBuff(BUFF_TYPE.Speed);

        if (data == null)
        {
            // Default multiplier 1x (so nothing)
            return 1f;
        }

        return data.buffMultiplier;
    }

    public float GetJumpBuffMultiplier()
    {
        BuffData data = buffManager.GetActiveBuff(BUFF_TYPE.Jump);

        if (data == null)
        {
            // Default multiplier 1x (so nothing)
            return 1f;
        }

        return data.buffMultiplier;
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

    public void BroadcastGoldEarned(int goldAmount)
    {
        gold += goldAmount;
        OnGoldEarned?.Invoke( gold );
        BroadcastGoldChanged(); // I know... I know
    }

    public void BroadcastGoldSpent( int goldAmount )
    {
        gold -= goldAmount;
        OnGoldSpent?.Invoke( gold );
        BroadcastGoldChanged(); // I know... I know
    }

    public void BroadcastGoldChanged()
    {
        OnGoldAmountChanged?.Invoke( gold );
    }
}
