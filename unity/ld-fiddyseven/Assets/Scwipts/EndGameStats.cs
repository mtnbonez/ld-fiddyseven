using TMPro;
using UnityEngine;

public class EndGameStats : MonoBehaviour
{
    StatsManager statsManager;
    public GameObject GoldCounter;
    public GameObject GoldSpent;
    public GameObject RocksBusted;

    void OnEnable()
    {
        statsManager = GameManager.Instance.GetStatsManager();

        string goldEarned = statsManager.playerStats.GoldEarned.ToString();
        string GoldSpent = statsManager.playerStats.GoldSpent.ToString();
        string RocksBusted = statsManager.playerStats.NormalRocksBroken.ToString(); 

        GoldCounter.GetComponent<TextMeshProUGUI>().text = goldEarned;
        GoldCounter.GetComponent<TextMeshProUGUI>().text = GoldSpent;
        GoldCounter.GetComponent<TextMeshProUGUI>().text = RocksBusted;
    }

}
