using System.Collections.Generic;
using UnityEngine;

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
        {BUFF_TYPE.TEST_BUFF_1, new BuffData(BUFF_TYPE.TEST_BUFF_1, "Test Buff 1", 100)},
        {BUFF_TYPE.TEST_BUFF_2, new BuffData(BUFF_TYPE.TEST_BUFF_2, "Test Buff 2", 200)},
        {BUFF_TYPE.TEST_BUFF_3, new BuffData(BUFF_TYPE.TEST_BUFF_3, "Test Buff 3", 300)},
        {BUFF_TYPE.TEST_BUFF_4, new BuffData(BUFF_TYPE.TEST_BUFF_4, "Test Buff 4", 400)},
        {BUFF_TYPE.TEST_BUFF_5, new BuffData(BUFF_TYPE.TEST_BUFF_5, "Test Buff 5", 500)},
    };
    
    public static BuffData GetBuffData(BUFF_TYPE buffType )
    {
        return BuffList[buffType];
    }

    public static Dictionary<BUFF_TYPE, BuffData> GetBuffList()
    {
        return BuffList;
    }
}

public struct BuffData
{
    public Buff.BUFF_TYPE buffType;
    public string buffName;
    public int buffCost;

    public BuffData( Buff.BUFF_TYPE type, string name, int cost )
    {
        buffType = type;
        buffName = name;
        buffCost = cost;
    }
}
