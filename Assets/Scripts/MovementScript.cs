using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour, IMovementScript
{

    public enum State
    {
        Normal,
        Attacking,
        Jump
    }

    public State state;
    private float inputX = 0;
    private float inputY = 0;
    private Vector3 moveVector;

    private void Awake()
    {
        state = State.Normal;
    }

    void Update()
    {
        switch (state)
        {
            case State.Normal:
                inputX = Input.GetAxisRaw("Horizontal");
                inputY = Input.GetAxisRaw("Vertical");
                GetComponent<IMoveVelocityScript>().SetVelocity(new Vector3(inputX, inputY));
                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    GetComponent<IAnimationScript>().Jump(() => state = State.Normal);
                    state = State.Jump;
                }

                break;
            case State.Attacking:
                break;
            case State.Jump:
                break;
        }


    }

    public void SetMovement(int stateNum)
    {
        switch (stateNum)
        {
            case 0:
                state = State.Normal;
                break;
            case 1:
                state = State.Attacking;
                break;
            case 2:
                state = State.Jump;
                break;
        }
    }
}