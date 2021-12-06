using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public Animator TransitionAnimator;

    public void LevelSelect() {
        SceneManager.LoadScene("Level Select");
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("Menu Scene");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void ViewHighscores() {
        SceneManager.LoadScene("Highscores");
    }

    public void NextLevelTransition() {
        TransitionAnimator.SetTrigger("End Level");
    }
    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSelectTransition() {
        TransitionAnimator.SetTrigger("Level Selected");
    }
    public void GoToLevel() {
        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
    }

    public void BlitzMode() {
        SceneManager.LoadScene("Blitz Mode");
    }
}
