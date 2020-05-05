using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour, IAnimationScript
{
    private Animator animator;
    private Vector3 playerScale;
    private int numOfClicks = 0;
    private float lastClick = 0;
    private const float MAX_COMBO_DELAY = 0.5f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (Time.time - lastClick > MAX_COMBO_DELAY)
            numOfClicks = 0;
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            lastClick = Time.time;
            numOfClicks++;
            if (numOfClicks == 1) animator.SetBool("punch1", true);
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
            animator.SetBool("punch1", false);
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

    public void Move(Vector3 velocityVector)
    {
        animator.SetFloat("velocity", velocityVector.magnitude);
        playerScale = transform.localScale;
        playerScale.x = velocityVector.x != 0 ? velocityVector.x : playerScale.x;
        transform.localScale = playerScale;

    }

    public void Jump(Func<object> func)
    {
        animator.SetTrigger("jump");
        func();
    }
}