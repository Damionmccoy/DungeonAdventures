using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private int damageAmount;
    public int DamageAmount { get => damageAmount; set => damageAmount = value; }

    [SerializeField] private Transform spawnPoint;
    public Transform SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    [SerializeField] private float range;
    public float Range { get => range; set => range = value; }

    [SerializeField] private GameObject projectile;
    public GameObject Projectile { get => projectile; set => projectile = value; }

    [SerializeField] private float projectileSpeed = 30;

    public void Fire()
    {
        Rigidbody2D obj = Instantiate(projectile, spawnPoint.position, transform.rotation).GetComponent<Rigidbody2D>();
        obj.velocity = transform.up * projectileSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false; //keep the ray from detecting the collider. 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
