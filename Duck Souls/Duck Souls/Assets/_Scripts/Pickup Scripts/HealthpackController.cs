using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthpackController : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public float floatSpeed = 1f;

    public float healthpackTravelRange = 1f;    //total distance the healthpack will travel

    private float healthpackMinHeight = 1f;
    private float healthpackMaxHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        float currentY = transform.position.y;
        healthpackMinHeight = currentY - (healthpackTravelRange / 2);
        healthpackMaxHeight = currentY + (healthpackTravelRange / 2);
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

