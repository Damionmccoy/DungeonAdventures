
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat 
{
    private int _baseValue;             //The base value of the stat
    private int _buffValue;             //The amount of the buff to this stat
    private int _expToLevel;            //The total amount of exp needed to raise this skill
    private float _levelModifier;       //The modifier applied to the exp needed to raise the skill

    public BaseStat()
    {
        _baseValue = 0;
        _buffValue = 0;
        _expToLevel = 100;
        _levelModifier = 1.1f;
    }

    //Properties
    public int BaseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; }
    }

    public int BuffValue
    {
        get { return _buffValue; }
        set { _buffValue = value; }
    }

    public int ExpToLevel 
    {
        get { return _expToLevel; }
        set { _expToLevel = value; }
    }

    public float LevelModifier
    {
        get { return _levelModifier; }
        set { _levelModifier = value; }
    }

    private int CalculateExpToLevel()
    {
        return Mathf.RoundToInt(_expToLevel * _levelModifier);
    }

    public void LevelUp()
    {
        _expToLevel = CalculateExpToLevel();
        _baseValue++;
    }

    public int AdjustedBaseValue
    {
        get { return _baseValue + _buffValue; }
    }

}
