using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySentry : MonoBehaviour
{

    public float rotationSpeed = 3f;
    public float viewDistance = 5;
    /// <summary>
    /// wont fire unless assigned
    /// </summary>
    public GameObject projectile;
    public Transform SpawnLocation;
    public float TimeBetweenShots;
    private float shotTime;

    public LineRenderer lineOfSight;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false; //keep the ray from detecting the collider. 
        shotTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, viewDistance);

        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position,hitInfo.point,Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            if (hitInfo.collider.CompareTag("Player"))
            {
                if(shotTime <= 0)
                {
                    shotTime = TimeBetweenShots;
                    Instantiate(projectile, SpawnLocation.position, transform.rotation);
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * viewDistance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * viewDistance);
        }
        shotTime -= Time.deltaTime;
        lineOfSight.SetPosition(0, transform.position);
    }
}
