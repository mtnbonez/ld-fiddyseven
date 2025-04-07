using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    [SerializeField]
    private List<Buff.BUFF_ID> buffs;

    private Dictionary<Buff.BUFF_ID, BuffContent> BuffInventoryData = new Dictionary<Buff.BUFF_ID, BuffContent>();

    public Dictionary<Buff.BUFF_ID, BuffContent> GetBuffInventoryData()
    {
        return BuffInventoryData;
    }

    private void BuildInventoryData()
    {
        foreach (Buff.BUFF_ID buffID in buffs)
        {
            if (!BuffInventoryData.ContainsKey(buffID))
            {
                BuffInventoryData.Add(buffID, Buff.GetBuffData(buffID));
            }
        }
    }

    private void Start()
    {
        BuildInventoryData();
    }
}