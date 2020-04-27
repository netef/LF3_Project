using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 100;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hitbox"))
        {
            health -= 20;
            if (health <= 0)
            {
                animator.SetTrigger("die");
                this.enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
