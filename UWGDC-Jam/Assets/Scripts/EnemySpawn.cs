using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs = new GameObject[0];
    private BoxCollider2D[] spawnBoxes;
    public string waveText;
    public float spawnTimeMin, spawnTimeMax;
    public int spawnCount;
    private float nextSpawnTime;
    private int spawned;

    public EnemySpawn nextWave;
    private bool calledDeadEvent = false;

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(spawnTimeMin, spawnTimeMax);
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        spawnBoxes = transform.parent.GetComponentsInChildren<BoxCollider2D>();
        SetNextSpawnTime();
        nextSpawnTime += 6;
        spawned = 0;
        calledDeadEvent = false;
        yield return new WaitForSeconds(3.0f);
        GameObject.Find("EventText").GetComponent<EventMessage>().ShowMesssage(waveText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime && spawned < spawnCount)
        {
            SetNextSpawnTime();
            Bounds bounds = spawnBoxes[Random.Range(0, spawnBoxes.Length)].bounds; // world space
            Vector3 pointInBounds = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 0);
            var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
            enemy.transform.position = pointInBounds;
            enemy.transform.parent = transform;
            spawned++;
        }

        if (spawned == spawnCount && !calledDeadEvent && transform.childCount == 0)
        {
            calledDeadEvent = true;
            if (nextWave != null)
                nextWave.enabled = true;
        }
    }
}
