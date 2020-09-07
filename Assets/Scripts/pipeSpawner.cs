using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    public float maxYpos;
    public float SpawnTime;
    public GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        // StartSpawningPipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawningPipe(){
        InvokeRepeating("SpawnPipes", 0.2f, SpawnTime);
    }

    public void StopSpawningPipe(){
        CancelInvoke("StopSpawningPipe");
    }

    void SpawnPipes(){
        Instantiate(pipe, new Vector3(transform.position.x,Random.Range(-maxYpos, maxYpos),0), Quaternion.identity);
    }
}
