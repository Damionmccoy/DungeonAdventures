using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    private PlayerCharacter _toon;
    // Start is called before the first frame update
    void Start()
    {
        _toon = new PlayerCharacter();
        _toon.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
