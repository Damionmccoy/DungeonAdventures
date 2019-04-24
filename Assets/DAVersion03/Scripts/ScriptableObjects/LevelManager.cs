using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelGeneration))]
public class LevelManager : MonoBehaviour
{
    public LevelData levelData;
    [SerializeField]
    private List<ThemeObject> selectedThemes;
    [SerializeField]
    private LevelGeneration lvlGenerator;

    public void Start()
    {
        lvlGenerator = GetComponent<LevelGeneration>();
        selectedThemes = new List<ThemeObject>();
    }
}
