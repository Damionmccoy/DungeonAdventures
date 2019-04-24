using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "New Level")]
public class LevelData : ScriptableObject
{
    public new string name;

    public List<ThemeObject> Themes;
    public int NumberOfLevels;
    public int LevelsPerTheme;
    public int EnemyLevelMin;
    public int EnemyLevelMax;
    
}
