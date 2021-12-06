using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    public static int levelsCompleted = 0;
    public Button[] Levels;
    public Button BlitzMode;
    public Sprite Star;
    void Update()
    {
        if(Input.GetKey(KeyCode.M) && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.W)) {
            levelsCompleted = 19;
            SceneManager.LoadScene("Level Select");
        }
    }

    public void Start() {
        Levels = this.GetComponentsInChildren<Button>();
        for(int i = 0; i < Levels.Length; i++) {
            if(levelsCompleted >= i) {
                Levels[i].interactable = true;
            }
            if(levelsCompleted > i) {
                Levels[i].GetComponent<Image>().sprite = Star;
                Levels[i].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(80, 80);
            }
        }
        if(levelsCompleted >= 20) {
            BlitzMode.gameObject.SetActive(true);
        }
    }
}
