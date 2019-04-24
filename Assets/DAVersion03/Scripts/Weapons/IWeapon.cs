using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    // Start is called before the first frame update
    int DamageAmount { get; set; }
    Transform SpawnPoint { get; set; }
    float Range { get; set; }
    GameObject Projectile { get; set; }

    void Fire();

}
