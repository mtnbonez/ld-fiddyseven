using System.Collections.Generic;

public class BuffManager
{
    private List<Buff.BUFF_TYPE> activeBuffs = new List<Buff.BUFF_TYPE>();

    public void AddBuff( Buff.BUFF_TYPE buff )
    {
        activeBuffs.Add( buff );
    }

    public void RemoveBuff( Buff.BUFF_TYPE buff )
    {
        activeBuffs.Remove( buff );
    }

    public List<Buff.BUFF_TYPE> GetActiveBuffs()
    {
        return activeBuffs;
    }

    public void ClearAllBuffs()
    {
        activeBuffs.Clear();
    }
}
