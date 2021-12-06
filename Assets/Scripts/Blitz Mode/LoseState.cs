using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseState : MonoBehaviour
{
    public GameObject LosePanel;
    public Text scoreText;
    void Update()
    {
        if(Hearts.RemainingHearts == 0) {
            LosePanel.gameObject.SetActive(true);
        }
        scoreText.text = "Score: " + EquationGenerator.score;
    }
}
