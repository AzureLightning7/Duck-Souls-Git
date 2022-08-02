using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthpackController : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public float floatSpeed = 1f;

    public float healthpackMinHeight = 0.5f;
    public float healthpackMaxHeight = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        floatSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotateSpeed/2, 0);   //constantly rotate around the y axis

        if (transform.position.y <= healthpackMinHeight || transform.position.y >= healthpackMaxHeight)
        {
            floatSpeed *= -1;
        }

        transform.Translate(Vector3.up * Time.deltaTime * floatSpeed/2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

