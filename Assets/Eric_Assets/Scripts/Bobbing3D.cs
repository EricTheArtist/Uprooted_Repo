using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing3D : MonoBehaviour
{
    float originalY;
    public bool spinning = true;
    public float bobbingSpeed =1;
    public float floatStrength = 0.3f;// You can change this in the Unity Editor to 
                                      // change the range of y positions that are possible.
    public float addedheight = 0.5f;

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        
        transform.position = new Vector3(transform.position.x,
            originalY + addedheight + ((float)Mathf.Sin(Time.time * bobbingSpeed) * floatStrength),
            transform.position.z);
        if (spinning == true)
        {
            transform.Rotate(0, 0.5f, 0);
        }
    }
}
