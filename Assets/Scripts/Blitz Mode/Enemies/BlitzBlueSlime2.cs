using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitzBlueSlime2 : MonoBehaviour {
    public GameObject GameSystem;
    public EquationGenerator script;
    public Vector2 position;
    private int tempNum;

    public void Awake() {
        GameObject GameSystem = GameObject.Find("Game");
        script = GameSystem.GetComponent<EquationGenerator>();
    }
    public void Update() {
        transform.Translate(-2 * Time.deltaTime * Spawner.speed, 0, 0);
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Target") {
            Debug.Log("Working");
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
            }
        }
    }
}
