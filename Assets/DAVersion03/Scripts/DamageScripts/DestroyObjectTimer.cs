using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Use this script to destroy and object after a set number of seconds.
/// </summary>


public class DestroyObjectTimer : MonoBehaviour
{
    public float Time2Destroy;

    //float counter = 0;
    // Update is called once per frame
    void Update()
    {
        if(Time2Destroy <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Time2Destroy -= Time.deltaTime;
        }
    }
}
