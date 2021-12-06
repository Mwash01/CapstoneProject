using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject[] Enemies2;
    public GameObject[] Enemies3;
    public float spawnDelay = 4f;
    public float untilNextSpawn = 0f;
    public static float speed;

    void Start()
    {
        speed = 0.5f;
    }

    void Update()
    {
        if (Time.time >= untilNextSpawn) {
            SpawnEnemy();
            untilNextSpawn = Time.time + spawnDelay;
            spawnDelay *= 0.985f;
            speed = speed + 0.05f;
        }
    }
    
    public void SpawnEnemy() {
        Vector2 randomPosition = new Vector2(21f, Random.Range(-9f, 0.2f));
        if (EquationGenerator.score < 20) {
            Instantiate(Enemies[Random.Range(0, 4)], randomPosition, transform.rotation);
        }
        else if (EquationGenerator.score < 50) {
            Instantiate(Enemies2[Random.Range(0, 8)], randomPosition, transform.rotation);
        }
        else {
            Instantiate(Enemies3[Random.Range(0, 4)], randomPosition, transform.rotation);
        }
    }
}
