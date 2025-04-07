using System.Collections.Generic;

public class Buff
{

    public enum BUFF_ID
    {
        All,
        SpeedPlus25,
        JumpPlus25,
        AttackRangePlus10,
        SizePlus100,
        SizeMinus20,
        Vision25,
        Vision100,
        Gold10000,

        TallWithAttackRange
    }

    public enum BUFF_TYPE
    {
        Speed,
        Jump,
        AttackRange,
        Height,
        VisionRange,
        Gold,
    }

    private static readonly Dictionary<BUFF_ID, BuffContent> BuffList = new Dictionary<BUFF_ID, BuffContent> {
        {BUFF_ID.SpeedPlus25, new BuffContent(
            "Speed +25%",
            10,
            new List<BuffData>(){
                new BuffData(BUFF_ID.SpeedPlus25, BUFF_TYPE.Speed, 1.25f)
            } 
        )},
        {BUFF_ID.JumpPlus25, new BuffContent(
            "Jump +25%",
            20,
            new List<BuffData>(){
                new BuffData(BUFF_ID.JumpPlus25, BUFF_TYPE.Jump, 1.25f)
            } 
        )},
        {BUFF_ID.AttackRangePlus10, new BuffContent(
            "Attack Range +10%",
            30,
            new List<BuffData>(){
                new BuffData(BUFF_ID.AttackRangePlus10, BUFF_TYPE.AttackRange, 1.1f)
            } 
        )},
        {BUFF_ID.SizeMinus20, new BuffContent(
            "Shorty -20%",
            5,
            new List<BuffData>(){
                new BuffData(BUFF_ID.SizeMinus20, BUFF_TYPE.Height, 0.8f)
            }
        )},
        {BUFF_ID.Vision25, new BuffContent(
            "Vision +25%",
            10,
            new List<BuffData>(){
                new BuffData(BUFF_ID.Vision25, BUFF_TYPE.VisionRange, 1.25f)
            } 
        )},

        // DRAWBACK + BUFFS
        {BUFF_ID.TallWithAttackRange, new BuffContent(
            "Daddy Long Legs",
            0,
            new List<BuffData>(){
                new BuffData(BUFF_ID.SizePlus100, BUFF_TYPE.Height, 2f),
                new BuffData(BUFF_ID.Vision100, BUFF_TYPE.VisionRange, 2f)
            }
          )
        },

        // DEBUG
        {BUFF_ID.All, new BuffContent(
            "All",
            100,
            new List<BuffData>(){
                new BuffData(BUFF_ID.SpeedPlus25, BUFF_TYPE.Speed, 2f),
                new BuffData(BUFF_ID.JumpPlus25, BUFF_TYPE.Jump, 20f),
                new BuffData(BUFF_ID.SizePlus100, BUFF_TYPE.Height, 2f)
            }
          )
        },
        {BUFF_ID.Gold10000, new BuffContent(
            "Gold DADDY",
            0,
            new List<BuffData>(){
                new BuffData(BUFF_ID.Gold10000, BUFF_TYPE.Gold, 10000f)
            }
          )
        },
    };
    
    public static BuffContent GetBuffData(BUFF_ID buffId)
    {
        return BuffList[buffId];
    }

    public static Dictionary<BUFF_ID, BuffContent> GetBuffList()
    {
        return BuffList;
    }
}

// Changed to class so we can pass-by-reference
public class BuffData
{
    public Buff.BUFF_ID buffId;
    public Buff.BUFF_TYPE buffType;
    public float buffMultiplier;

    public BuffData(Buff.BUFF_ID id, Buff.BUFF_TYPE type, float amount)
    {
        buffId = id;
        buffType = type;
        buffMultiplier = amount;
    }
}


public class BuffContent
{
    public string name;
    public int buffCost;
    public List<BuffData> buffs;
    
    public BuffContent(string name, int buffCost, List<BuffData> buffs)
    {
        this.name = name;
        this.buffCost = buffCost;
        this.buffs = buffs;
    }
}