using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float MoveSpeed = 30;
    public float retreatDistance = 10;
    public float stopDistance = 15;
    public float viewDistance = 50;
    Transform player;
    /// <summary>
    /// wont fire unless assigned
    /// </summary>
    public GameObject projectile;
    public Transform SpawnLocation;
    public float TimeBetweenShots;
    private float shotTime;
    

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.queriesStartInColliders = false; //keep the ray from detecting the collider. 
        shotTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shotTime -= Time.deltaTime;
        if (Vector2.Distance(transform.position, player.position) < viewDistance 
            && Vector2.Distance(transform.position,player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, MoveSpeed * Time.deltaTime);
            Fire();
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDistance
            && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = transform.position = transform.position;
            Fire();
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -MoveSpeed * Time.deltaTime);
            Fire();
        }
    }


    void Fire()
    {
        if (shotTime <= 0)
        {
            shotTime = TimeBetweenShots;
            Instantiate(projectile, SpawnLocation.position, transform.rotation);
        }
        
    }
}
