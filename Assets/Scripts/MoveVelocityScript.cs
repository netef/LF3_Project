using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocityScript : MonoBehaviour, IMoveVelocityScript
{
    private const float MOVEMENT_SPEED = 4f;
    private Vector3 velocityVector;
    private CharacterController cc;
    private float gravity = 0.25f;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    void FixedUpdate()
    {
        if (velocityVector.y != 0)
            velocityVector.y -= gravity;
        cc.Move(velocityVector * MOVEMENT_SPEED * Time.fixedDeltaTime);
        GetComponent<IAnimationScript>().Move(velocityVector);
    }
}