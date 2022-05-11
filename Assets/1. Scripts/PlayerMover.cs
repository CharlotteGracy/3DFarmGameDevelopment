using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 10;
    private Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

	private	CharacterController	characterController;

    private Vector3 moveVec;
    private float moveH;
    private float moveV;

    


private void Update()
{
    Move();
}

    private void Move(){
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        moveVec = transform.right*moveH + transform.forward*moveV;
        characterController.Move(moveVec * moveSpeed * Time.deltaTime);

    }
    
    
}
