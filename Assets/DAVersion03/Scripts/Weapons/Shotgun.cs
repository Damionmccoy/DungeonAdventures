using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IWeapon
{


    [SerializeField] private int damageAmount;
    public int DamageAmount { get => damageAmount; set => damageAmount = value; }

    [SerializeField] private Transform spawnPoint;
    public Transform SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    [SerializeField] private float range;
    public float Range { get => range; set => range = value; }

    [SerializeField] private GameObject projectile;
    public GameObject Projectile { get => projectile; set => projectile = value; }

    [SerializeField] private float speed = 30;

    public int numOfProjectiles = 3;


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false; //keep the ray from detecting the collider. 
    }

 
    public void Fire()
    {

        float startAngle = -Mathf.FloorToInt((numOfProjectiles - 1) / 2) * 30;

        for (int i = 0; i < numOfProjectiles; i++, startAngle += 30)
        {
            Instantiate(projectile, transform.position, Quaternion.AngleAxis(startAngle, transform.up) * transform.rotation);
        }
    }

}
