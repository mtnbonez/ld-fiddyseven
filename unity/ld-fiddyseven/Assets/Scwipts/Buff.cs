using System.Collections.Generic;

public class Buff
{
    public enum BUFF_TYPE
    {
        TEST_BUFF_1,
        TEST_BUFF_2,
        TEST_BUFF_3,
        TEST_BUFF_4,
    }

    private Dictionary<BUFF_TYPE, string> BuffList = new Dictionary<BUFF_TYPE, string> { 
        {BUFF_TYPE.TEST_BUFF_1, "Test Buff 1"},
        {BUFF_TYPE.TEST_BUFF_2, "Test Buff 2"},
        {BUFF_TYPE.TEST_BUFF_3, "Test Buff 3"},
        {BUFF_TYPE.TEST_BUFF_4, "Test Buff 4"},
    };
    
    public string GetBuffString(BUFF_TYPE buffType )
    {
        return BuffList[buffType];
    }

    public Dictionary<BUFF_TYPE, string> GetBuffList()
    {
        return BuffList;
    }
}
