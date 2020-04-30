using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float inputX = 0;
    private float inputY = 0;
    private Vector3 moveVector;
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        GetComponent<IMoveVelocityScript>().SetVelocity(new Vector3(inputX, inputY));
    }
}