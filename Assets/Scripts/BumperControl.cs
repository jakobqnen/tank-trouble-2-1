using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperControl : MonoBehaviour
{
    int wallsTouching;
    public bool isOnWall
    {
        get
        {
            return wallsTouching > 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Barrier"))
        {
            wallsTouching++;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Barrier"))
        {
            wallsTouching--;
        }
    }
}