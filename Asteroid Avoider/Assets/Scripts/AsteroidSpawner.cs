using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] garbagePrefabs;
    [SerializeField] private float secondsBetweenSpawn = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private float timer;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnGarbage();

            timer = secondsBetweenSpawn;
        }
    }

    private void SpawnGarbage()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnLocation = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                spawnLocation.x = 0;
                spawnLocation.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                spawnLocation.x = Random.value;
                spawnLocation.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
            case 2:
                spawnLocation.x = 1;
                spawnLocation.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 3:
                spawnLocation.x = Random.value;
                spawnLocation.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnLocation);
        worldSpawnPoint.z = 0;

        GameObject selectedPrefab = garbagePrefabs[Random.Range(0, garbagePrefabs.Length)];

        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        GameObject newInstance = Instantiate(selectedPrefab, worldSpawnPoint, randomRotation);

        newInstance.GetComponent<Rigidbody>().velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}
