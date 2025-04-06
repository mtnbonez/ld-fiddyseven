using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    [SerializeField]
    private List<Buff.BUFF_TYPE> buffs;

    private Dictionary<Buff.BUFF_TYPE, BuffData> BuffInventoryData = new Dictionary<Buff.BUFF_TYPE, BuffData>();

    public Dictionary<Buff.BUFF_TYPE, BuffData> GetBuffInventoryData()
    {
        return BuffInventoryData;
    }

    private void BuildInventoryData()
    {
        foreach (Buff.BUFF_TYPE buffType in buffs)
        {
            BuffInventoryData.Add( buffType, Buff.GetBuffData( buffType ) );
        }
    }

    private void Start()
    {
        BuildInventoryData();
    }
}