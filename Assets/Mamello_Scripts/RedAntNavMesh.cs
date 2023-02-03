using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedAntNavMesh : MonoBehaviour
{
    //[SerializeField] private ArrayList houseList;

    

    [SerializeField] private Transform moveTarget; //

    private NavMeshAgent navMeshAgent;
    /*[SerializeField] private GameObject[] taggedHouses;
    [SerializeField] private GameObject[] totalHouses;
    public Transform[] totalHouses;*/
    public GameObject[] HouseTransformsArray;
    public GameObject Closesthouse;
    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //GameObject temphouse = GameObject.FindWithTag("HousePrefab");
        //moveTarget = temphouse.GetComponent<Transform>();

        HouseTransformsArray  = GameObject.FindGameObjectsWithTag("HousePrefab");
        compareDistances();
        moveTarget = Closesthouse.transform;
        navMeshAgent.destination = moveTarget.position;

    }

    void compareDistances()
    {
        float lowestDist = Mathf.Infinity;
        Vector3 pos = transform.position;

        for (int i = 0; i < HouseTransformsArray.Length; i++)
        {

            float dist = Vector3.Distance(HouseTransformsArray[i].transform.position, pos);

            if (dist < lowestDist)
            {
                lowestDist = dist;
                Closesthouse = HouseTransformsArray[i];
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //making RedAnt movetowards target
        if(moveTarget!= null)
        {
            navMeshAgent.destination = moveTarget.position;
        }
        else if(moveTarget == null)
        {
            HouseTransformsArray = GameObject.FindGameObjectsWithTag("HousePrefab");
            compareDistances();
            moveTarget = Closesthouse.transform;
            navMeshAgent.destination = moveTarget.position;
        }
        
        //FindClosestTarget();
    }

   /* public void FindClosestTarget2()
    {
        totalHouses = new ___[taggedHouses.Length];
        for (int houseCount = 0; houseCount < totalHouses.Length; houseCount++)
        {
            totalHouses[houseCount] = taggedHouses[houseCount].GetComponent<___>();
        }
    }*/

    /*public void FindClosestTarget()
    {
        //Transform closestTarget= null;
        float closestTargetDistance = float.MaxValue;
        NavMeshPath path = null; //to check all waypoints player can move to 
        NavMeshPath shortestPath = null;

        //looping through amount of houses then spawning till house count reaches total amount of houses
        for (int houseCount = 0; houseCount < totalHouses.Length; houseCount++)
        {
            if (totalHouses[houseCount] == null)
            {
                continue;
            }

            path = new NavMeshPath();

            //calculating path from current pos to target pos 
            if (NavMesh.CalculatePath(transform.position, totalHouses[houseCount].position, navMeshAgent.areaMask, path))
            {
                //checking distance between current distance & 1st corner of navMesh
                float distance = Vector3.Distance(transform.position, path.corners[0]);
                //looping through remaining corners 
                for (int corner = 1; corner < path.corners.Length; corner++)
                {
                    distance += Vector3.Distance(path.corners[corner - 1], path.corners[corner]);
                }

                //setting closest target distance to be distance calculated above
                if (distance < closestTargetDistance)
                {
                    closestTargetDistance = distance;
                    //closestTarget = totalHouses[houseCount];
                    shortestPath = path;
                }

                if (shortestPath != null)
                {
                    navMeshAgent.SetPath(shortestPath);
                }
            }
        }
    }*/
}
