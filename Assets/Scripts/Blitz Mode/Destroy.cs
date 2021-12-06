using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void DestroyEnemy() {
        Destroy(GameObject.FindWithTag("Projectile"));
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Projectile") {
            DestroyEnemy();
        }
    }
}
