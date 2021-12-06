using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeKing : MonoBehaviour {
    public GameObject GameSystem;
    public EquationGenerator script;
    public Vector2 position;
    public GameObject targetPrefab;
    public int Health = 4;
    public int tempNum;

    public Sprite BlueSprite;
    public Sprite YellowSprite;
    public Sprite GreenSprite;

    public void Awake() {
        GameObject GameSystem = GameObject.Find("Game");
        script = GameSystem.GetComponent<EquationGenerator>();
    }

    public void Update() {
        switch (Health) {
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = BlueSprite;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = YellowSprite;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = GreenSprite;
                break;
        }
    }

    public void OnMouseDown() {
        switch (Health) {
            case 4:
                if (EquationGenerator.equationExist == false) {
                    EquationGenerator.equationExist = true;
                    EquationGenerator.num1 = Random.Range(5, 20);
                    EquationGenerator.num2 = Random.Range(5, 20);
                    script.Addition();
                    SpawnTarget();
                 }
                break;
            case 3:
                if (EquationGenerator.equationExist == false) {
                    EquationGenerator.equationExist = true;

                    EquationGenerator.num1 = Random.Range(10, 20);
                    EquationGenerator.num2 = Random.Range(10, 20);
                    if (EquationGenerator.num2 > EquationGenerator.num1) {  // Prevents equations where the answer is negative
                        tempNum = EquationGenerator.num2;
                        EquationGenerator.num2 = EquationGenerator.num1;
                        EquationGenerator.num1 = tempNum;
                    }
                    script.Subtraction();
                    SpawnTarget();
                }
                break;
            case 2:
                if (EquationGenerator.equationExist == false) {
                    EquationGenerator.equationExist = true;
                    EquationGenerator.num1 = Random.Range(1, 10);
                    EquationGenerator.num2 = Random.Range(1, 10);
                    script.Multiplication();
                    SpawnTarget();
                }
                break;
            case 1:
                if (EquationGenerator.equationExist == false) {
                    EquationGenerator.equationExist = true;
                    EquationGenerator.num1 = Random.Range(1, 20);
                    EquationGenerator.num2 = Random.Range(2, 20);

                    while (EquationGenerator.num1 % EquationGenerator.num2 != 0 | EquationGenerator.num1 / EquationGenerator.num2 == 1) {  //Loops until it generates a problem where the answer does not have a decimal
                        EquationGenerator.num1 = Random.Range(1, 20);
                        EquationGenerator.num2 = Random.Range(2, 20);
                    }
                    script.Division();
                    SpawnTarget();
                }
                break;
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
            Health = Health - 1;
            Destroy(GameObject.FindWithTag("Target"));
            Destroy(GameObject.FindWithTag("Projectile"));
            if (Health == 0) {
                DestroyEnemy();
            }
        }
    }
}
