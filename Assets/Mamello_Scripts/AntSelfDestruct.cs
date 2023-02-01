using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSelfDestruct : MonoBehaviour
{
    [SerializeField] private float lifetimeCountdown = 5f;

    // Update is called once per frame
    void Update()
    {
        //counting down till 0
        lifetimeCountdown -= Time.deltaTime;
        if (lifetimeCountdown <= 0f)
        {
            Destroy(gameObject);
        }

        //test
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }*/
    }
}
