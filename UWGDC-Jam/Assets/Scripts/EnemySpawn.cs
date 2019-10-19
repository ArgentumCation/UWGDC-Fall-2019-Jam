using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private BoxCollider2D spawnBox;
    public GameObject enemyPrefab;
    public float spawnRate;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        spawnBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > spawnRate)
        {
            timer = Time.time;
            Bounds bounds = spawnBox.bounds; // world space
            Vector3 pointInBounds = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 0);
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = pointInBounds;
        }
    }
}
