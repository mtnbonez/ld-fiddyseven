using TMPro;
using UnityEngine;

public class PlayerGoldUI : MonoBehaviour
{
    public static PlayerGoldUI Instance;

    [SerializeField]
    TextMeshProUGUI goldAmount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else
        {
            Destroy( gameObject );
        }
    }

    private void OnEnable()
    {
        GameManager.OnGoldEarned += UpdateGoldUI;
        GameManager.OnGoldSpent += UpdateGoldUI;
    }

    private void OnDisable()
    {
        GameManager.OnGoldEarned -= UpdateGoldUI;
        GameManager.OnGoldSpent -= UpdateGoldUI;
    }

    void UpdateGoldUI(int newGoldAmount )
    {
        goldAmount.text = $"{newGoldAmount}";
    }
}
