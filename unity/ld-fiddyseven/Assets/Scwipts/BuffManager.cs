using System.Collections.Generic;

public class BuffManager
{
    //private List<Buff.BUFF_TYPE> activeBuffs = new List<Buff.BUFF_TYPE>();
    private Dictionary<Buff.BUFF_TYPE, BuffData> activeBuffs = new Dictionary<Buff.BUFF_TYPE, BuffData>();

    public void AddBuff( Buff.BUFF_TYPE buff, BuffData data )
    {
        if (!activeBuffs.TryAdd(buff, data))
        {
            activeBuffs[buff].buffMultiplier += data.buffMultiplier;
        }
    }

    public void RemoveBuff( Buff.BUFF_TYPE buff )
    {
        activeBuffs.Remove(buff);
    }

    public BuffData GetActiveBuff(Buff.BUFF_TYPE buff)
    {
        if (activeBuffs.TryGetValue(buff, out BuffData data))
        {
            return data;
        }

        return null;
    }

    public void ClearAllBuffs()
    {
        activeBuffs.Clear();
    }
}
