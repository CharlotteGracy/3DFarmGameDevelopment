using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    private GameSceneButtonChange toolSwitch;
    private FieldAction fieldAction;

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
        toolSwitch = GameObject.Find("GameManager").GetComponent<GameSceneButtonChange>();

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
        mouseY = Input.GetAxis("Mouse Y")* verticalSpeed;

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
        //hitInfo로 어느 땅이 맞았는지 정보 가져오기

        bool fieldCheck = Physics.Raycast(ray, out hitInfo, 1.3f, fieldLayer);
        
        //TODO: 스페이스 바를 눌렀을 때 도구(삽, 곡괭이 등)를 휘두를 수 있도록 함
        if(Input.GetButtonDown("Jump") && fieldCheck == true){
          //  Debug.Log(hitInfo.transform.gameObject.name);
            fieldAction = hitInfo.transform.gameObject.GetComponent<FieldAction>();

            if(toolSwitch.ShovelSelectOn == true){
                UseShovel();

            }
            else if(toolSwitch.SeedSelectOn == true){
                
                UseSeed();

            }
            else if(toolSwitch.WateringCanSelectOn == true){
                UseWateringCan();

            }
        }
    }

    
    
    public void UseShovel(){
        //TODO: 삽 움직이는 애니메이션, 땅의 Texture를 파인 땅 Texture로 바꿔주기

        //밭의 상태로는 FieldAction 함수 가져오기
        fieldAction.ShovelUsed();
    }

    public void UseSeed(){
        fieldAction.SeedUsed();

        //TODO: 돈 차감, 당근인지 양배추인지 정보
        //1. 씨 뿌렸을 때 금액 차감
        



        //2. 작물 종류에 따라 금액 다르게 적용하기
        //3. 금액이 부족할 때 버튼을 비활성화 하기

    }

    public void UseWateringCan(){
        fieldAction.WateringCanUsed();


    }


    
    
}
