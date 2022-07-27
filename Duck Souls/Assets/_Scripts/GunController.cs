using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunBarrelEnd;  //The location where bullets are spawned
    public GameObject bullet;       //Bullet Gameobject prefab
    public float fireRate = 5f;     //Fire rate of the gun
    public float reloadTime = 1f;   
    public int magazineSize = 20;
    private float canFire = 0f;

    //Audio Variables
    private AudioSource gunAudio;   //Audio Source to play clips
    public AudioClip shootSound;    //Sound that plays when the gun shoots
    public AudioClip reloadSound;   //Reload Sound

    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource>(); // Gun Audio Source
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) //if left click is down
        {
            if (Time.time > canFire)    //if gametime is longer than canFire
            {
                Instantiate(bullet, gunBarrelEnd.position, gunBarrelEnd.rotation);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, 1f);
                canFire = Time.time + (1 / fireRate);
            }
        }
    }
}
