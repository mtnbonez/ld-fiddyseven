using System.Collections.Generic;

public class Buff
{

    public enum BUFF_ID
    {
        All,
        SpeedPlus100,
        JumpPlus1000,
        AttackRangePlus100,
        SizePlus100,
        SizeMinus50,
        Vision25,
        Gold10000,
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
        {BUFF_ID.SpeedPlus100, new BuffContent(
            "Speed +100%",
            100,
            new List<BuffData>(){
                new BuffData(BUFF_ID.SpeedPlus100, BUFF_TYPE.Speed,  2f)
            } 
        )},
        {BUFF_ID.JumpPlus1000, new BuffContent(
            "Jump +1000%",
            200,
            new List<BuffData>(){
                new BuffData(BUFF_ID.JumpPlus1000, BUFF_TYPE.Jump, 20f)
            } 
        )},
        {BUFF_ID.AttackRangePlus100, new BuffContent(
            "Attack Range +100%",
            300,
            new List<BuffData>(){
                new BuffData(BUFF_ID.AttackRangePlus100, BUFF_TYPE.AttackRange, 2f)
            } 
        )},
        {BUFF_ID.SizePlus100, new BuffContent(
            "Tall +100%",
            400,
            new List<BuffData>(){
                new BuffData(BUFF_ID.SizePlus100, BUFF_TYPE.Height, 2f)
            }
        )},
        {BUFF_ID.SizeMinus50, new BuffContent(
            "Shorty -50%",
            500,
            new List<BuffData>(){
                new BuffData(BUFF_ID.SizeMinus50, BUFF_TYPE.Height, 0.5f)
            }
        )},
        {BUFF_ID.Vision25, new BuffContent(
            "Vision +25%",
            100,
            new List<BuffData>(){
                new BuffData(BUFF_ID.Vision25, BUFF_TYPE.VisionRange, 1.25f)
            } 
        )},
        {BUFF_ID.All, new BuffContent(
            "All",
            100,
            new List<BuffData>(){
                new BuffData(BUFF_ID.SpeedPlus100, BUFF_TYPE.Speed, 2f),
                new BuffData(BUFF_ID.JumpPlus1000, BUFF_TYPE.Jump, 20f),
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