using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocityScript : MonoBehaviour, IMoveVelocityScript
{
    private const float MOVEMENT_SPEED = 200f;
    private Vector3 velocityVector;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    void FixedUpdate()
    {
        rb.velocity = velocityVector * MOVEMENT_SPEED * Time.fixedDeltaTime;
        GetComponent<IAnimationScript>().Move(velocityVector);
    }
}