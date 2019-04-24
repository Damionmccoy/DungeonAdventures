using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //For the door and wall prefabs 0--> vertical, 1--> horizontal
    [SerializeField]
    private GameObject doorPrefabs;
    [SerializeField]
    private GameObject wallPrefabs;
    [SerializeField]
    private DoorStatus doorState;
    [SerializeField]
    private bool PlaceVertically;
    public DoorStatus DoorState { get; }

    public GameObject door; 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //cast a ray to check for a wall using the bool set up to decide if its horizontal or vertical
        RaycastHit2D CheckHitLeft = Physics2D.Raycast(transform.position, Vector2.left, 1f);
        RaycastHit2D CheckHitRight = Physics2D.Raycast(transform.position, Vector2.right, 1f);
        RaycastHit2D CheckHitUp = Physics2D.Raycast(transform.position, Vector2.up, 1f);
        RaycastHit2D CheckHitDown = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        if (PlaceVertically)
        {
            if (CheckHitLeft.transform.gameObject != null || CheckHitRight.transform.gameObject != null)
            {
                if(CheckHitLeft.transform.gameObject.tag == "Wall" || CheckHitRight.transform.gameObject.tag == "Wall")
                {
                    Instantiate(wallPrefabs, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(doorPrefabs, transform.position, transform.rotation);
                }
            }
        }
    }

    public void PlaceWall()
    {
        Debug.Log(" I need to place a wall");
    }

    public void PlaceDoor()
    {
        Debug.Log(" I need to place a wall");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            PlaceWall();
        }
    }

}


public enum DoorStatus
{
    UNLOCKED,
    LOCKED,
    WALL

}