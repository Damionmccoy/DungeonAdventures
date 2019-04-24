using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseCharacter : MonoBehaviour
{

    private string _name;
    private int _level;
    private uint _freeExp;

    private Attribute[] _primaryAttribute;
    private Vital[] _vital;
    private Skill[] _skill;


    public string Name { get { return _name; }set { _name = value; }}
    public int Level { get { return _level; } set { _level = value; } }
    public uint FreeExp { get { return _freeExp; } set { _freeExp = value; } }

    public void Awake()
    {
        _name = string.Empty;
        _level = 0;
        _freeExp = 0;

        _primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        _vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        _skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

        SetupPrimaryAttributes();
        SetupSkills();
        SetupVitals();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExp(uint exp)
    {
        _freeExp += exp;
        CalculateLevel();
    }
    //Take the avarage of all the player skills and assign that as the player level
    public void CalculateLevel()
    {

    }
    private void SetupPrimaryAttributes()
    {
        for (int i = 0; i < _primaryAttribute.Length; i++)
        {
            _primaryAttribute[i] = new Attribute();
        }
    }
    private void SetupVitals()
    {
        for (int i = 0; i < _vital.Length; i++)
        {
            _vital[i] = new Vital();
        }
    }
    private void SetupSkills()
    {
        for (int i = 0; i < _skill.Length; i++)
        {
            _skill[i] = new Skill();
        }
    }

    public Attribute GetPrimaryAttribute(int _index)
    {
        return _primaryAttribute[_index];
    }

    public Vital GetVital(int _index)
    {
        return _vital[_index];
    }

    public Skill GetSkill(int _index)
    {
        return _skill[_index];
    }

    private void SetupVitalModifiers()
    {
        //health
        GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constituion),0.5f));
        //energy
        GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constituion), 1f));
        //mana
        GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 1f));
    }
    private void SetupSkillModifiers()
    {

        //Melee Offence 
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), 0.33f));
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Agility), 0.33f));
        //Melee Deffence
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constituion), 0.33f));
        //Magic offence
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 0.33f));
        //Magic Deffence
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 0.33f));
        //Range Offence
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
        //Range Deffence
        GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
        GetSkill((int)SkillName.Ranged_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Agility), 0.33f));
    }

    public void StatUpdate()
    {
        for (int i = 0; i < _vital.Length; i++)
        {
            _vital[i].Update();
        }
        for (int i = 0; i < _skill.Length; i++)
        {
            _skill[i].Update();
        }
    }
}
