using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float gravity = -9.81f;
    private Rigidbody rigid;
    
	private	CharacterController	characterController;

    private Vector3 moveVec;
    private float moveH;
    private float moveV;
    private float moveY;
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    float mouseX;
    float mouseY;    

    
    private void Awake(){

        characterController = GetComponent<CharacterController>();

    }


    private void Update(){
     Move();
     UseTool();
     Rotate();
    }

    private void Move(){
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        if(characterController.isGrounded == false){
 			moveY += gravity * Time.deltaTime;
           
        }

        moveVec = transform.right*moveH + transform.forward*moveV;
        characterController.Move(moveVec * moveSpeed * Time.deltaTime);

    }
    private void Rotate(){
        mouseX = Input.GetAxis("Mouse X")* horizontalSpeed;
        mouseY = Input.GetAxis("Mouse Y")*verticalSpeed;

        yRotation += mouseX;
        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        /*

        if(characterController.isGrounded == false){

        }
        */
    }

    private void UseTool(){
        //TODO: 스페이스 바를 눌렀을 때 도구(삽, 곡괭이 등)를 휘두를 수 있도록 함
        if(Input.GetButtonDown("Jump")){
            Debug.Log("도구 휘두름");
        }
    }
    
    
}
