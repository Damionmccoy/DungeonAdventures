using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedStat : BaseStat
{

    private List<ModifyingAttribute> mods;         //A list of attributes that modify the stat
    private int modValue;                          // Stores the ammount added to the baseValue from the modifiers
    

    public ModifiedStat()
    {
        mods = new List<ModifyingAttribute>();
        modValue = 0;
    }

    public void AddModifier(ModifyingAttribute mod)
    {
        mods.Add(mod);
    }

    private void CalculateModValue()
    {
        modValue = 0;
        if(mods.Count > 0)
        {
            foreach(ModifyingAttribute att in mods)
            {
                modValue += Mathf.RoundToInt(att.attribute.AdjustedBaseValue * att.ratio);
            }
        }
    }

    public new int AdjustedBaseValue
    {
        get { return BaseValue + BuffValue + modValue; }
    }

    public void Update()
    {
        CalculateModValue();
    }
}

public struct ModifyingAttribute
{
    public Attribute attribute;
    public float ratio;
    public ModifyingAttribute(Attribute att, float rat)
    {
        attribute = att;
        ratio = rat;
    }
}