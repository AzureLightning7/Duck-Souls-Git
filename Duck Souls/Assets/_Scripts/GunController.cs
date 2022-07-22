using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunBarrelEnd;
    public GameObject bullet;
    public float fireRate = 5f;
    public float reloadTime = 1f;
    public int magazineSize = 20;
    private float canFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) //if left click is down
        {
            if (Time.time > canFire)    //if gametime is longer than canFire
            {
                Instantiate(bullet, gunBarrelEnd.position, gunBarrelEnd.rotation);
                canFire = Time.time + (1 / fireRate);
            }
        }
    }
}
