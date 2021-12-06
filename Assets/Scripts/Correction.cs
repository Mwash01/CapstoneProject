using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Correction : MonoBehaviour
{
    public GameObject correctionPanel;
    public Text displayAnswer;
    public Button GotIt;

    public void OnEnable() {
        displayAnswer.text = EquationGenerator.num1 + " " + EquationGenerator.equationType + " " + EquationGenerator.num2 + " = " + EquationGenerator.answer;
        transform.LeanMoveLocal(new Vector2(0, 30), 1).setEaseOutQuad();
    }
    
    public void RemovePanel() {
        Hearts.RemainingHearts -= 1;
        if(Hearts.RemainingHearts == 0) {
            EquationGenerator.equationExist = false;
            SceneManager.LoadScene("Level Select");
        }
        transform.LeanMoveLocal(new Vector2(0, 793f), 1).setOnComplete(DisablePanel);
    }
    public void DisablePanel() {
        EquationGenerator.equationExist = false;
        correctionPanel.SetActive(false);
        Destroy(GameObject.FindWithTag("Target"));
    }
}
