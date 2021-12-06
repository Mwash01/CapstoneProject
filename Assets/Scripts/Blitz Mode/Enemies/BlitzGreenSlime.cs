using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitzGreenSlime : MonoBehaviour {
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
            if (EquationGenerator.equationExist == false) {
                EquationGenerator.equationExist = true;
                EquationGenerator.num1 = Random.Range(1, 10);
                EquationGenerator.num2 = Random.Range(1, 10);

                while (EquationGenerator.num1 % EquationGenerator.num2 != 0) {  //Loops until it generates a problem where the answer does not have a decimal
                    EquationGenerator.num1 = Random.Range(1, 10);
                    EquationGenerator.num2 = Random.Range(1, 10);
                }
                script.Division();
            }
        }
    }
}
