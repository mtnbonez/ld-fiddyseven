using System;
using System.Collections.Generic;

public class BuffManager
{
    // This dictionary condenses all stats into multipliers!
    private Dictionary<Buff.BUFF_TYPE, BuffData> activeBuffs = new Dictionary<Buff.BUFF_TYPE, BuffData>();

    public Action<Buff.BUFF_TYPE> OnBuffAdded;

    public void AddBuffs(List<BuffData> data)
    {
        foreach (BuffData buff in data)
        {
            if (!activeBuffs.TryAdd(buff.buffType, buff))
            {
                activeBuffs[buff.buffType].buffMultiplier *= buff.buffMultiplier;
            }

            OnBuffAdded.Invoke(buff.buffType);
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
