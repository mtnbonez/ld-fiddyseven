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

    public GameObject RockVisionCircle;
    public Vector3 OriginalRockVisionCircleScale;

    public CapsuleCollider Character_Collider;
    public float Original_Character_Collider_Height;
    public Transform Art_Transform;
    public Vector3 Original_Art_Scale;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        buffManager = new BuffManager();
        buffManager.OnBuffAdded += OnBuffAdded;

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
            BroadcastGoldSpent(gold);
        }

        // Make this a function grrr
        if (RockVisionCircle != null && OriginalRockVisionCircleScale != null)
        {
            RockVisionCircle.transform.localScale = OriginalRockVisionCircleScale * GetVisionMultiplier();
        }
        else
        {
            Debug.LogWarning("RockVision scale variables not set!");
        }

        // Adjust art
        if (Art_Transform != null && Original_Art_Scale != null)
        {
            Art_Transform.transform.localScale = new Vector3(Original_Art_Scale.x, Original_Art_Scale.y * GetHeightMultiplier(), Original_Art_Scale.z);
        }
        else
        {
            Debug.LogWarning("Character size variables not set!");
        }

        // Adjust collider
        if (Character_Collider != null && Original_Character_Collider_Height != 0)
        {
            Character_Collider.height = Original_Character_Collider_Height * GetHeightMultiplier();
        }
        else
        {
            Debug.LogWarning("Collider size variables not set!");
        }
    }

    public void OnBuffAdded(BUFF_TYPE buffType)
    {
        if (buffType == BUFF_TYPE.VisionRange)
        {
            if (RockVisionCircle != null && OriginalRockVisionCircleScale != null)
            {
                RockVisionCircle.transform.localScale = OriginalRockVisionCircleScale * GetVisionMultiplier();
            }
            else
            {
                Debug.LogWarning("RockVision scale variables not set!");
            }
        }
        else if (buffType == BUFF_TYPE.Height)
        {
            // Adjust art
            if (Art_Transform != null && Original_Art_Scale != null)
            {
                Art_Transform.transform.localScale = new Vector3(Original_Art_Scale.x, Original_Art_Scale.y * GetHeightMultiplier(), Original_Art_Scale.z);
            }
            else
            {
                Debug.LogWarning("Character size variables not set!");
            }

            // Adjust collider
            if (Character_Collider != null && Original_Character_Collider_Height != 0)
            {
                Character_Collider.height = Original_Character_Collider_Height * GetHeightMultiplier();
            }
            else
            {
                Debug.LogWarning("Collider size variables not set!");
            }
        }
        else if (buffType == BUFF_TYPE.Gold)
        {
            BroadcastGoldEarned(10000);
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

    public float GetAttackRangeBuffMultiplier()
    {
        BuffData data = buffManager.GetActiveBuff(BUFF_TYPE.AttackRange);

        if (data == null)
        {
            // Default multiplier 1x (so nothing)
            return 1f;
        }

        return data.buffMultiplier;
    }

    public float GetVisionMultiplier()
    {
        BuffData data = buffManager.GetActiveBuff(BUFF_TYPE.VisionRange);

        if (data == null)
        {
            // Default multiplier 1x (so nothing)
            return 1f;
        }

        return data.buffMultiplier;
    }

    public float GetHeightMultiplier()
    {
        BuffData data = buffManager.GetActiveBuff(BUFF_TYPE.Height);

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
