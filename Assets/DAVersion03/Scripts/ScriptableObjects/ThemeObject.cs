using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Theme",menuName = "New Theme")]
public class ThemeObject : ScriptableObject
{

    public new string name;

    public Texture2D tex;
    public GameObject doorU, doorD, doorL, doorR, doorWall;
    public ColorToGameObject[] mappings;
    public List<GameObject> Enemies;

}
