using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public GameObject WinPanel;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) {
            WinPanel.gameObject.SetActive(true);
            if (LevelProgress.levelsCompleted < int.Parse(SceneManager.GetActiveScene().name.Substring(6))) {
                LevelProgress.levelsCompleted = int.Parse(SceneManager.GetActiveScene().name.Substring(6));
            }
        }
    }
}