using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private float spikesPerSecond;
    [SerializeField] private float minSpawn;
    [SerializeField] private float maxSpawn;

    private bool activePattern;
    private float lastPatternTime;
    private bool zigzag;

    void Start()
    {
        activePattern = false;
        lastPatternTime = 0.0f;
        InvokeRepeating("SpawnSpike", 0, 1 / spikesPerSecond);
    }
    void Update()
    {
        if (Time.time - lastPatternTime >= 10.0f && !activePattern)
        {
            zigzag = false;
            activePattern = true;
            CancelInvoke(); // Stop random spikes

            int pattern = Random.Range(0, 3); // Pick a random pattern
            switch (pattern)
            {
                case 0:
                    Invoke("SpikePattern1", 1.5f);
                    break;
                case 1:
                    Invoke("SpikePattern2", 1.5f);
                    break;
                case 2:
                    Invoke("SpikePattern3", 1.5f);
                    break;
            }
            if ((pattern == 1 || pattern == 2) && Random.Range(0, 2) == 0) // 50% Chance of occuring after a zig-zag
            {
                Invoke(pattern == 2 ? "SpikePattern2" : "SpikePattern3", 7.0f); // Invoke other zig-zag
                zigzag = true;
            }
            Invoke("UpdateActive", 5.5f + (zigzag ? 7.0f : 0.0f)); // wait 5.5 seconds before resuming random spikes, add 7 seconds if a zig zag occured
        }

        if (Time.timeSinceLevelLoad <= 30.0f)
        {
            spikesPerSecond = 2.0f + Time.timeSinceLevelLoad / 30.0f;
        }
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

    private void UpdateActive()
    {
        activePattern = false;
        lastPatternTime = Time.time;
        InvokeRepeating("SpawnSpike", 0, 1 / spikesPerSecond);
    }

    private void SpikePattern1() // Cone Pattern
    {
        float center = Random.Range(minSpawn / 2, maxSpawn / 2);

        for (int i = 0; i < 5; i++)
        {
            Instantiate( // Left Spike
                spikePrefab,
                transform.position + Vector3.right * (minSpawn + i * (center - 1 - minSpawn) / 5) + Vector3.up * i,
                Quaternion.identity,
                transform
            );

            Instantiate( // Right Spike
                spikePrefab,
                transform.position + Vector3.right * (maxSpawn - i * (maxSpawn - 1 - center) / 5) + Vector3.up * i,
                Quaternion.identity,
                transform
            );
        }
    }

    private void SpikePattern2() // Zig-Zag: Left to Right
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(
                spikePrefab,
                transform.position + Vector3.right * (minSpawn + i * (maxSpawn - minSpawn - 2) / 10) + Vector3.up * i,
                Quaternion.identity,
                transform
            );
        }
    }

    private void SpikePattern3() // Zig-Zag: Right to Left
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(
                spikePrefab,
                transform.position + Vector3.right * (maxSpawn + i * (minSpawn - maxSpawn + 2) / 10) + Vector3.up * i,
                Quaternion.identity,
                transform
            );
        }
    }
}
