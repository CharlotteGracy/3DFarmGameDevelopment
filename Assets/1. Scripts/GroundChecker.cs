using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GroundChecker 
{
    public Transform feetPos;
    public float detectSize;

    [SerializeField]
    public abstract bool isGrounded();
    public abstract bool IsGrounded();
}
