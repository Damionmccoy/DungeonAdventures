using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script should tell the changeroomsystem which room to move the camera and player too
/// </summary>
public class DoorTrigger : MonoBehaviour
{
    public float DoorXPos;
    public float DoorYPos;
    public ChangeRoomSystem roomChanger;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameCamera").GetComponent<ChangeRoomSystem>() != null)
        {
            roomChanger = GameObject.FindGameObjectWithTag("GameCamera").GetComponent<ChangeRoomSystem>();
        }
        else
        {
            Debug.Log("room changer is null");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.CompareTag("Player") && roomChanger != null)
        {
                Debug.Log("jump room");
                roomChanger.ChangeRoom(DoorYPos, DoorXPos,other.transform);
            
        }
    }
}
