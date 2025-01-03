using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWhenSpawned : MonoBehaviour
{
    private float randomAngle;
    // Start is called before the first frame update
    void Start()
    {
        randomAngle = Random.Range(0f, 360f);
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + randomAngle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
