using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnRate;
    float x, y;
    private Vector2 spawnPos;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(-0.5f, 0.5f);
        spawnPos.x += x;
        spawnPos.y += y;
        Instantiate(enemies[0], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnEnemies());
    }

}
