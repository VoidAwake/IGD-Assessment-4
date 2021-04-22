using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private int spikesPerSecond;
    [SerializeField] private float minSpawn;
    [SerializeField] private float maxSpawn;
    void Start()
    {
        InvokeRepeating("SpawnSpike", 0, 1/spikesPerSecond);
    }

    private void SpawnSpike()
    {
        float position = Random.Range(minSpawn, maxSpawn);
        
        Instantiate(
            spikePrefab,
            transform.position + Vector3.right * position,
            Quaternion.identity,
            transform
        );
    }
}
