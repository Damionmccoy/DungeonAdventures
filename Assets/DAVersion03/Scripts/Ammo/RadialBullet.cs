using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBullet : MonoBehaviour
{

    public int NumberOfProjectiles;
    public float Speed;
    public GameObject Projectile;
    public Transform SpawnPoint;
    public bool IsBomb;
    private Vector2 startPoint;
    private const float radius =5f; //to help find the move direction
    private const float PI = 3.1415f;

    void Start()
    {
        Physics2D.queriesStartInColliders = false; //keep the ray from detecting the collider. 

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && IsBomb)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        startPoint = transform.position;
        SpawnProjectiles(NumberOfProjectiles);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void SpawnProjectiles(int _numOfProjectiles)
    {
        float angleStep = 360f / _numOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numOfProjectiles -1; i++)
        {
            //This is trig I hate trig so this is magic to me but it figures out the angle the projectile will fire based on the anglestep
            float projectileX = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileY = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileX, projectileY);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * Speed;

            GameObject tempObj = Instantiate(Projectile, startPoint, Quaternion.identity);
            tempObj.GetComponent<Rigidbody2D>().velocity =  new Vector2( projectileMoveDirection.x, projectileMoveDirection.y);
            print("shoot radial");
            angle += angleStep;

        }

    }

}
