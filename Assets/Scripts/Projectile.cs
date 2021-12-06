using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public float speed = 10f;
    public GameObject Explosion;

    public void Start() {
        target = GameObject.FindWithTag("Target");
    }

    public void Update() {
        if (SceneManager.GetActiveScene().name != "Blitz Mode") {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 20 * Time.deltaTime);
        }
        DestroyProjectile();
    }
    public void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Enemy") {
            EquationGenerator.equationExist = false;
            ExplosionAnimation();
            EquationGenerator.score = EquationGenerator.score + 1;
        }
    }

    public void ExplosionAnimation() {
        Instantiate(Explosion, transform.position, transform.rotation);
    }
    
    public void DestroyProjectile() {
        if(Hearts.RemainingHearts == 0) {
            Destroy(gameObject);
        }
    }
}
