using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable] //showing wave list & its variables in inspector
    public class Wave
    {
        public string name;
        public Transform redAnt;
        public int spawnAmount;
        public float spwanRate;
    }

    public Wave[] waveList;
    public Transform[] spawnPoints;

    [SerializeField] private float timeBetweenWaves = 5f; // maybe 
    [SerializeField] private float waveCountdown;

    private SpawnState spawnState = SpawnState.COUNTING;
    private int nextWave = 0;
    private float antSearchCountdown = 1f; //timer to make IsEnemyAlive() check update with time instead of frame (for performance)

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("no spawn points");
        }

        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        //waiting before restarting countdown for next wave (waiting after spawned all ants as per ant count)
        if (spawnState == SpawnState.WAITING)
        {
            Debug.Log("Found Ants =" + IsAntAlive());
            //checking if ants still alive
            if (!IsAntAlive()) //not processing
            {
                //start new round
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }

        }

        if (waveCountdown <= 0f)
        {
            //ensuring not already spawning when it's time to spawn 
            if (spawnState != SpawnState.SPAWNING)
            {
                //waiting before spawning next wave from list as per index number
                StartCoroutine(SpawnWave(waveList[nextWave]));
            }
        }
        else
        {
            //counting down till 0
            waveCountdown -= Time.deltaTime;
        }
    }

    //checking if ants are alive after countdown
    bool IsAntAlive()
    {
        //counting down till 0
        antSearchCountdown -= Time.deltaTime;
        if (antSearchCountdown <= 0f)
        {
            //resetting countdown
            antSearchCountdown = 1f;

            //ants not alive
            if (GameObject.FindGameObjectsWithTag("RedAnt").Length == 0)
            {
                return false;
            }
        }
        //else: ants alive
        return true;
    }

    void WaveCompleted()
    {
        Debug.Log("wave complete");

        spawnState = SpawnState.COUNTING;
        //reseting countdown
        waveCountdown = timeBetweenWaves;

        //resetting wave index
            //preventing error if next wave > wavelist size (next wave = current wave +1 > (number of waves - current waveindex))
        if (nextWave + 1 > waveList.Length -1)
        {
            nextWave = 0;
            Debug.Log("all waves completed. Looping...");
        }
        else
        {
            //updating wave index by 1
            nextWave++;
        }
    }
   
    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log("is spawning wave " + wave.name);

        spawnState = SpawnState.SPAWNING;

        //looping through amount of red ants then spawning till ant count reaches spawn amount
        for (int antCount = 0; antCount < wave.spawnAmount; antCount++)
        {
            SpawnRedAnts(wave.redAnt);
            //waiting before spawning next ant (before continuing loop)
                //Delay = 1 / spawnRate (can call rate delay delay)
            yield return new WaitForSeconds(1f / wave.spwanRate);
        }

        spawnState = SpawnState.WAITING;

        yield break;

    }

    void SpawnRedAnts(Transform _redAnt)
    {
        Debug.Log("Spawning Red Ants: " + _redAnt.name);
        //randomly selecting spawnpoint for each ant (maybe can use logic for wave)
        Transform spawnPointTransform = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_redAnt, spawnPointTransform.position, spawnPointTransform.rotation);

    }
}
