using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody rb;
    public float bulletSpeed = 20f; //speed of the bullet
    public float lifetime = 15f;    //how long the bullet lasts

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // reference rigidbody
        Invoke("Remove", lifetime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * bulletSpeed;  //move the bullet forward
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void Remove()
    {
        Destroy(gameObject);
    }
}
