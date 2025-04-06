using System.Collections.Generic;

public class Buff
{
    public enum BUFF_TYPE
    {
        TEST_BUFF_1,
        TEST_BUFF_2,
        TEST_BUFF_3,
        TEST_BUFF_4,
        TEST_BUFF_5,
    }

    private static readonly Dictionary<BUFF_TYPE, BuffData> BuffList = new Dictionary<BUFF_TYPE, BuffData> { 
        {BUFF_TYPE.TEST_BUFF_1, new BuffData("Test Buff 1", 100)},
        {BUFF_TYPE.TEST_BUFF_2, new BuffData("Test Buff 2", 200)},
        {BUFF_TYPE.TEST_BUFF_3, new BuffData("Test Buff 3", 300)},
        {BUFF_TYPE.TEST_BUFF_4, new BuffData("Test Buff 4", 400)},
        {BUFF_TYPE.TEST_BUFF_5, new BuffData("Test Buff 5", 500)},
    };
    
    public static BuffData GetBuffData(BUFF_TYPE buffType )
    {
        return BuffList[buffType];
    }

    public Dictionary<BUFF_TYPE, BuffData> GetBuffList()
    {
        return BuffList;
    }
}

public struct BuffData
{
    public string buffName;
    public int buffCost;

    public BuffData( string name, int cost )
    {
        buffName = name;
        buffCost = cost;
    }
}
