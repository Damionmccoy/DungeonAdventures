using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDistroyer : MonoBehaviour
{


    //Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomSpawnPoint"))
        {
            Destroy(other.gameObject);
        }
    }
}
