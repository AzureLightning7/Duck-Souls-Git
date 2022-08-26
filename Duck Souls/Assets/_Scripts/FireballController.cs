using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Rigidbody rb;
    public float fireBallSpeed = 20f; //speed of the bullet
    public float lifetime = 15f;    //how long the bullet lasts
    public float rotateSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // reference rigidbody
        Invoke("Remove", lifetime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * fireBallSpeed;  //move the bullet forward
        transform.Rotate(0, 0, rotateSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            print("Floor Ball!");
        }
        Destroy(gameObject);
    }

    void Remove()
    {
        Destroy(gameObject);
    }
}
