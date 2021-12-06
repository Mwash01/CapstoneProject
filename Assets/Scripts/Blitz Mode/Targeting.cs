using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public float speed = 100f;
    public GameObject Barrier;
    public GameObject target;
    public Vector2 barrierPosition;
    public void Start() {
        barrierPosition = Barrier.transform.position;
    }
    public void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0) {
            //transform.position = Vector2.MoveTowards(transform.position, GameObject.FindWithTag("Enemy").transform.position, speed * Time.deltaTime);
            TargetEnemy();
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        DestroyTarget();
    }

    public GameObject TargetEnemy() { //Finds enemy closest to the barrier
        target = null;
        float closestEnemy = Mathf.Infinity;
        Vector2 enemyPosition;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies) {
            enemyPosition = enemy.transform.position;
            Vector2 DistanceFromBarrier = enemyPosition - barrierPosition;
            float distanceToBarrier = DistanceFromBarrier.sqrMagnitude;
            if(distanceToBarrier < closestEnemy) {
                closestEnemy = distanceToBarrier;
                target = enemy;
            }
        }

        return target;
    }
    public void DestroyTarget() {
        if (Hearts.RemainingHearts == 0) {
            Destroy(gameObject);
        }
    }
}
