using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocityScript : MonoBehaviour, IMoveVelocityScript
{
    private const float MOVEMENT_SPEED = 4f;
    private Vector3 velocityVector;
    private CharacterController cc;
    private float gravityNormal = 9.8f;
    private float gravityJumped = 0.4f;

    void Awake() => cc = GetComponent<CharacterController>();
    public void SetVelocity(Vector3 velocityVector) => this.velocityVector = velocityVector;

    void FixedUpdate()
    {
        GetComponent<IAnimationScript>().Move(velocityVector);
        if (velocityVector.y == 0)
            velocityVector.y -= gravityNormal;
        else
            velocityVector.y -= gravityJumped;
        cc.Move(velocityVector * MOVEMENT_SPEED * Time.fixedDeltaTime);
    }
}