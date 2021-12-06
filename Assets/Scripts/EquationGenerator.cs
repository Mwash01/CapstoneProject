using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EquationGenerator : MonoBehaviour
{
    public Text equationDisplay;
    public InputField answerInput;
    public GameObject correctionPanel;
    public GameObject GameSystem;
    public GameObject Panel;
    public GameObject projectilePrefab;
    public Animator animator;
    public static int num1;
    public static int num2;
    public static int answer;
    public static string equationType;
    public static bool equationExist = false;
    private int userAnswer;
    private bool ready = false;
    private int tempNum;
    public static int score;

    public void Start() {
        score = 0;
        equationExist = false;
    }

    public void Update() {
        if (ready == true) {
            if (Input.GetKeyUp(KeyCode.Return)) {
                checkAnswer();
            }
        }
        if(SceneManager.GetActiveScene().name == "Blitz Mode") {
            answerInput.Select();
            answerInput.ActivateInputField();
        }
    }

    public void Addition() {
        equationType = "+";
        //num1 = Random.Range(1, 10);
        //num2 = Random.Range(1, 10);
        answer = num1 + num2;
        equationDisplay.text = num1 + " + " + num2 + " = ";

        answerInput.gameObject.SetActive(true);
        answerInput.Select();
        answerInput.ActivateInputField();

        ready = true;
        //GameSystem.GetComponent<Buttons>().DisableButtons();
    }

    public void Subtraction() {
        equationType = "-";
        /*num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);

        if (num2 > num1) {  // Prevents equations where the answer is negative
            tempNum = num2;
            num2 = num1;
            num1 = tempNum;
        }*/

        answer = num1 - num2;
        equationDisplay.text = num1 + " - " + num2 + " = ";

        answerInput.gameObject.SetActive(true);
        answerInput.Select();
        answerInput.ActivateInputField();

        ready = true;

        //GameSystem.GetComponent<Buttons>().DisableButtons();
    }

    public void Multiplication() {
        equationType = "X";
        //num1 = Random.Range(1, 10);
        //num2 = Random.Range(1, 10);

        answer = num1 * num2;
        equationDisplay.text = num1 + " x " + num2 + " = ";

        answerInput.gameObject.SetActive(true);
        answerInput.Select();
        answerInput.ActivateInputField();

        ready = true;
        //GameSystem.GetComponent<Buttons>().DisableButtons();
    }

    public void Division() {
        equationType = "÷";
        /*num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);

        while(num1 % num2 != 0) {  //Loops until it generates a problem where the answer does not have a decimal
            num1 = Random.Range(1, 10);
            num2 = Random.Range(1, 10);
        }*/

        answer = num1 / num2;
        equationDisplay.text = num1 + " ÷ " + num2 + " = ";

        answerInput.gameObject.SetActive(true);
        answerInput.Select();
        answerInput.ActivateInputField();

        ready = true;
        //GameSystem.GetComponent<Buttons>().DisableButtons();
    }

    public void checkAnswer() {
        userAnswer = int.Parse(answerInput.text);
        if (SceneManager.GetActiveScene().name == "Blitz Mode") {
            if (userAnswer == answer) {
                Debug.Log("correct");
                SpawnProjectile();
            }
            else {
                Debug.Log("false");
                Hearts.RemainingHearts -= 1;
            }
        }
        else {
            if (userAnswer == answer) {
                Debug.Log("correct");
                //equationExist = false;
                animator.SetBool("Attacking", true);
                //SpawnProjectile();
            }
            else {
                Debug.Log("false");
                correctionPanel.gameObject.SetActive(true);
            }
            ready = false;
        }
    }

    public void SpawnProjectile() {
        if (Hearts.RemainingHearts > 0 && GameObject.FindGameObjectsWithTag("Projectile").Length == 0 && ready == true) {
            Instantiate(projectilePrefab, new Vector2(-3.8f, -2.45f), transform.rotation);
        }
        ready = false;
    }
}
