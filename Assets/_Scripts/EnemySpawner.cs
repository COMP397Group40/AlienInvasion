using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawnTime;
    public float spawnTimeRandom;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTimer();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            Instantiate(zombie, transform.position, Quaternion.identity);
            ResetSpawnTimer();
        }
    }

    void ResetSpawnTimer()
    {
        spawnTimer = (float)(spawnTime + Random.Range(0, spawnTimeRandom * 100) / 100.0);
    }
}
