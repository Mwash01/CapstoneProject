using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy2 : MonoBehaviour {
    public GameObject GameSystem;
    public EquationGenerator script;
    public Vector2 position;
    public GameObject targetPrefab;
    private int tempNum;

    public void Awake() {
        GameObject GameSystem = GameObject.Find("Game");
        script = GameSystem.GetComponent<EquationGenerator>();
    }

    public void OnMouseDown() {
        if (EquationGenerator.equationExist == false) {
            EquationGenerator.equationExist = true;

            EquationGenerator.num1 = Random.Range(10, 20);
            EquationGenerator.num2 = Random.Range(5, 20);
            if (EquationGenerator.num2 > EquationGenerator.num1) {  // Prevents equations where the answer is negative
                tempNum = EquationGenerator.num2;
                EquationGenerator.num2 = EquationGenerator.num1;
                EquationGenerator.num1 = tempNum;
            }
            script.Subtraction();
            SpawnTarget();
        }
    }

    public void SpawnTarget() {
        Instantiate(targetPrefab, transform.position, transform.rotation);
    }

    public void DestroyEnemy() {
        Destroy(GameObject.FindWithTag("Target"));
        Destroy(GameObject.FindWithTag("Projectile"));
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Projectile") {
            DestroyEnemy();
        }
    }
}
