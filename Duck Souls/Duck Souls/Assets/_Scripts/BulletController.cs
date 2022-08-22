using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody rb;
    public float bulletSpeed = 20f; //speed of the bullet
    public float lifetime = 15f;    //how long the bullet lasts
    public int bulletDamageAmount = 5;

    BossController bossController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // reference rigidbody
        Invoke("RemoveBullet", lifetime);

        bossController = GameObject.Find("Boss").GetComponent<BossController>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * bulletSpeed;  //move the bullet forward
        //transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            bossController.TakeDamage(bulletDamageAmount);
        }

        RemoveBullet();
    }

    void RemoveBullet()
    {
        Destroy(gameObject);
    }
}
