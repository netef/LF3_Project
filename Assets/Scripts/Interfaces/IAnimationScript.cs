using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationScript
{
    void Attack();
    void Move(Vector3 velocityVector);
}
