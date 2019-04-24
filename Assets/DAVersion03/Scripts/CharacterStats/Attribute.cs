using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : BaseStat
{

    public Attribute()
    {
        ExpToLevel = 50;
        LevelModifier = 1.25f;
    }


}

public enum AttributeName
{
    Might,
    Constituion,
    Agility,
    Speed,
    Concentration,
    Willpower,
    Charisma
}