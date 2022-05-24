using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    private GameSceneButtonChange shovelSwitch;
    public LayerMask fieldLayer;

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
        shovelSwitch = GameObject.Find("GameManager").GetComponent<GameSceneButtonChange>();

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
        moveVec.y = moveY;


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

        Vector3 destination = Camera.main.transform.forward;
        destination.y = -0.7f;
        Ray ray = new Ray(Camera.main.transform.position, destination);
        RaycastHit hitInfo;

        bool fieldCheck = Physics.Raycast(ray, out hitInfo, 1.3f, fieldLayer);

        
        //TODO: 스페이스 바를 눌렀을 때 도구(삽, 곡괭이 등)를 휘두를 수 있도록 함
        if(Input.GetButtonDown("Jump") && fieldCheck == true){




            if(shovelSwitch.ShovelSelectOn == true){
                UseShovel();

            }
            else if(shovelSwitch.SeedSelectOn == true){
                UseSeed();

            }
            else if(shovelSwitch.WateringCanSelectOn == true){
                UseWateringCan();

            }
        }
    }

    
    
    public void UseShovel(){
        //TODO: 삽 움직이는 애니메이션, 땅의 Texture를 파인 땅 Texture로 바꿔주기

        Debug.Log("삽 사용");


    }

    public void UseSeed(){
        Debug.Log("씨앗 사용");

    }

    public void UseWateringCan(){
        Debug.Log("물뿌리개 사용");

        //TODO: Field의 Texture 변경

    }


    
    
}
