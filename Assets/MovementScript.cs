using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    int numOfClicks = 0;
    float lastClick = 0;
    const float MAX_COMBO_DELAY = 0.9f;
    Vector3 playerScale;
    float inputX = 0;
    float inputY = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementManagement();
        AttackCombo();
        Flip();
    }

    private void Flip()
    {
        playerScale = transform.localScale;
        playerScale.x = inputX != 0 ? inputX : playerScale.x;
        transform.localScale = playerScale;
    }

    private void MovementManagement()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("velocity", rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * Time.fixedDeltaTime * 150, inputY * Time.fixedDeltaTime * 120);
    }

    private void AttackCombo()
    {
        if (Time.time - lastClick > MAX_COMBO_DELAY)
            numOfClicks = 0;
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            lastClick = Time.time;
            numOfClicks++;
            if (numOfClicks == 1)
                animator.SetBool("punch1", true);
            numOfClicks = Mathf.Clamp(numOfClicks, 0, 3);
        }
    }

    private void Punch1()
    {
        if (numOfClicks >= 2)
            animator.SetBool("punch2", true);
        else
        {
            animator.SetBool("punch1", false);
            numOfClicks = 0;
        }
    }
    private void Punch2()
    {
        if (numOfClicks >= 3)
            animator.SetBool("punch3", true);
        else
        {
            animator.SetBool("punch2", false);
            numOfClicks = 0;
        }
    }
    private void Punch3()
    {
        animator.SetBool("punch1", false);
        animator.SetBool("punch2", false);
        animator.SetBool("punch3", false);
        numOfClicks = 0;
    }


}