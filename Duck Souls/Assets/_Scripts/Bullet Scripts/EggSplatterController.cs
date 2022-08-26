using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSplatterController : MonoBehaviour
{
    public int eggSplatterLifetime = 2;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyEgg", eggSplatterLifetime);
    }

    void DestroyEgg()
    {
        Destroy(gameObject);
    }
}
