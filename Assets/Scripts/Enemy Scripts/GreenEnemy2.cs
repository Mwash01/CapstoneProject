using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy2 : MonoBehaviour {
    public GameObject GameSystem;
    public EquationGenerator script;
    public Vector2 position;
    public GameObject targetPrefab;

    public void Awake() {
        GameObject GameSystem = GameObject.Find("Game");
        script = GameSystem.GetComponent<EquationGenerator>();
    }

    public void OnMouseDown() {
        if (EquationGenerator.equationExist == false) {
            EquationGenerator.equationExist = true;
            EquationGenerator.num1 = Random.Range(1, 20);
            EquationGenerator.num2 = Random.Range(2, 20);

            while (EquationGenerator.num1 % EquationGenerator.num2 != 0 | EquationGenerator.num1/EquationGenerator.num2 == 1) {  //Loops until it generates a problem where the answer does not have a decimal
                EquationGenerator.num1 = Random.Range(1, 20);
                EquationGenerator.num2 = Random.Range(2, 20);
            }
            script.Division();
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
