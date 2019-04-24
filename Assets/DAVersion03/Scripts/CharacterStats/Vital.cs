using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vital : ModifiedStat
{

    private int curValue;

    public Vital()
    {
        curValue = 0;
        ExpToLevel = 75;
        LevelModifier = 1.2f;
    }

    public int CurValue
    {
        get {
            if( curValue > AdjustedBaseValue)
            {
                curValue = AdjustedBaseValue;
            }

            return curValue;
        }
        set { curValue = value; }
    }
}

public enum VitalName
{
    Health,
    Energy,
    Mana
}
