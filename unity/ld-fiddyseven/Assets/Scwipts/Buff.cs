using System.Collections.Generic;

public class Buff
{
    public enum BUFF_TYPE
    {
        Speed,
        Jump,
        TEST_BUFF_3,
        TEST_BUFF_4,
        TEST_BUFF_5,
    }

    private static readonly Dictionary<BUFF_TYPE, BuffData> BuffList = new Dictionary<BUFF_TYPE, BuffData> { 
        {BUFF_TYPE.Speed, new BuffData(BUFF_TYPE.Speed, "Speed +100%", 100, 2f)},
        {BUFF_TYPE.Jump, new BuffData(BUFF_TYPE.Jump, "Jump +1000%", 200, 20f)},
        {BUFF_TYPE.TEST_BUFF_3, new BuffData(BUFF_TYPE.TEST_BUFF_3, "Test Buff 3", 300, 0f)},
        {BUFF_TYPE.TEST_BUFF_4, new BuffData(BUFF_TYPE.TEST_BUFF_4, "Test Buff 4", 400, 0f)},
        {BUFF_TYPE.TEST_BUFF_5, new BuffData(BUFF_TYPE.TEST_BUFF_5, "Test Buff 5", 500, 0f)},
    };
    
    public static BuffData GetBuffData(BUFF_TYPE buffType)
    {
        return BuffList[buffType];
    }

    public static Dictionary<BUFF_TYPE, BuffData> GetBuffList()
    {
        return BuffList;
    }
}

// Changed to class so we can pass-by-reference
public class BuffData
{
    public Buff.BUFF_TYPE buffType;
    public string buffName;
    public int buffCost;
    public float buffMultiplier;

    public BuffData( Buff.BUFF_TYPE type, string name, int cost, float amount)
    {
        buffType = type;
        buffName = name;
        buffCost = cost;
        buffMultiplier = amount;
    }
}
