using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private BoxCollider2D spawnBox;
    public GameObject enemyPrefab;
    public float spawnTimeMin, spawnTimeMax;
    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        // initially longer spawn wait
        nextSpawnTime = Time.time + Random.Range(spawnTimeMin * 2, spawnTimeMax * 2);
        spawnBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + Random.Range(spawnTimeMin, spawnTimeMax);
            Bounds bounds = spawnBox.bounds; // world space
            Vector3 pointInBounds = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 0);
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = pointInBounds;
        }
    }
}
