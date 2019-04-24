using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyOnTriggerEnter : MonoBehaviour
{

    public bool DontDestroyWithPlayer = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(DontDestroyWithPlayer){
            if (!collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
