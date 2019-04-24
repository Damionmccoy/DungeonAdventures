using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int OpeningDirection;
    // 1 --> bottom door
    // 2 --> top door
    // 3 --> left door 
    // 4 --> right door

    //Referance to the rooms template object
    private RoomTemplate templates;
    //used to select which random roon of a specified opening. 
    private int rand;
    //Variable to declare the room has spawned
    public bool Spawned = false;



    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Room Template").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (Spawned == false)
        {

            if (OpeningDirection == 1)
            {
                rand = Random.Range(0, templates.BottomRooms.Length);
                Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
            }
            else if (OpeningDirection == 2)
            {
                rand = Random.Range(0, templates.TopRooms.Length);
                Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation);
            }
            else if (OpeningDirection == 3)
            {
                rand = Random.Range(0, templates.LeftRooms.Length);
                Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation);
            }
            else if (OpeningDirection == 4)
            {
                rand = Random.Range(0, templates.RightRooms.Length);
                Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation);
            }
            Spawned = true;
        }
        else
        {
            Debug.Log("This room has already tried to spawn");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("RoomSpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>() != null && other.GetComponent<RoomSpawner>().Spawned == false && Spawned == false)
            {
                rand = Random.Range(0, templates.ClosedRooms.Length);
                Instantiate(templates.ClosedRooms[rand], transform.position, Quaternion.identity);
                Destroy(this);
            }
            Spawned = true;
        }
    }

}
