public class StatsManager
{
    // I'm better than this, but i'm tired. - Matt

    public PlayerStats playerStats;

    public StatsManager()
    {
        PlayerStats playerStats = new PlayerStats( 0, 0, 0, 0, 0 );
    }

    public PlayerStats GetPlayerStats() { return playerStats; }

    public void AddGoldEarned(int amount )
    {
        playerStats.GoldEarned += amount;
        GameManager.Instance.BroadcastGoldEarned( amount );
    }

    public void AddGoldSpent( int amount )
    {
        playerStats.GoldSpent += amount;
    }

    public void AddNormalRocksBroken( int amount )
    {
        playerStats.NormalRocksBroken += amount;
    }

    public void AddHardRocksBroken( int amount )
    {
        playerStats.HardRocksBroken += amount;
    }

    public void AddGoldRocksBroken( int amount )
    {
        playerStats.GoldRocksBroken += amount;
    }
}

public struct PlayerStats
{
    public int GoldEarned;
    public int GoldSpent;
    public int NormalRocksBroken;
    public int HardRocksBroken;
    public int GoldRocksBroken;

    public PlayerStats( int goldEarned, int goldSpent, int normalRocks, int hardRocks, int goldRocks )
    {
        GoldEarned = goldEarned;
        GoldSpent = goldSpent;
        NormalRocksBroken = normalRocks;
        HardRocksBroken = hardRocks;
        GoldRocksBroken = goldRocks;
    }
}