using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedAntNavMesh : MonoBehaviour
{
    [SerializeField] private Transform moveTarget;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //making RedAnt movetowards target
        navMeshAgent.destination = moveTarget.position;

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }*/
       
    }
}
