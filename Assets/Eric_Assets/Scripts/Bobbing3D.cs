using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing3D : MonoBehaviour
{
    float originalY;

    public float floatStrength = 0.3f; // You can change this in the Unity Editor to 
                                    // change the range of y positions that are possible.

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        
        transform.position = new Vector3(transform.position.x,
            originalY + 0.5f + ((float)Mathf.Sin(Time.time) * floatStrength),
            transform.position.z);
        transform.Rotate(0, 0.5f, 0);
    }
}
