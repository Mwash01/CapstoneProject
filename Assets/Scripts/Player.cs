using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Animator animator;

    public void SpawnProjectile() {
        animator.SetBool("Attacking", false);
        if (SceneManager.GetActiveScene().name == "Blitz Mode") {
            Instantiate(projectilePrefab, new Vector2(-3.8f, -2.45f), transform.rotation);
        }
        else {

            Instantiate(projectilePrefab, new Vector2(-4, 0.3f), transform.rotation);
        }
    }
}
