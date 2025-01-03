using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWarning : MonoBehaviour
{

    private GameObject lava;
    private float distance;
    public GameObject lavaWarning;
    // Start is called before the first frame update
    void Start()
    {
        lava = GameObject.FindGameObjectWithTag("Lava");
        //lavaWarning = GameObject.Find("Lava Warning");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(lava.transform.position, transform.position);
        //Debug.Log("Distance: " + distance);
        if (distance < 27) 
        { 
            lavaWarning.SetActive(true);
        }
        else
        {
            lavaWarning.SetActive(false);
        }
    }
}
