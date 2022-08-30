using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//동물 캐릭터가 자유롭게 배회하는 AI
//랜덤으로 방향을 설정함.
//선정한 방향에 장애물이 있을 시 다른 방향으로
//물체 혹은 다른 동물과 충돌하면 다른 방향으로
//닭: 4초 걷다가 2초 쉬며 생산
//돼지: 5초 걷다가 2초 쉬며 생산
//젖소: 7초 걷다가 2초 쉬며 생산

public class AnimalProducing : MonoBehaviour

{

    public float walkSpeed = 0.001f;
    private float speed;
    public float distance;
    public float moveTime;
    public float pauseTime;
    [SerializeField]
    private float time;
    public Vector3 rotateDirection;




    public GameObject egg;
    public GameObject ham;
    public GameObject milk;

    public enum AnimalType{HEN, PIG, COW,};
   // public enum CurrentState{IDLE, WALK,};
    public AnimalType animalType;

    public bool timerOn;
    public bool isWalking;
   // public float walkTime;
    //public float idleTime;
    public bool timeToProduce;
    

    [SerializeField]
    private Rigidbody rigidbody;
    //[SerializeField]
    private Animator animator;

    

    // Start is called before the first frame update
    private void Start() {
        animator = this.gameObject.GetComponent<Animator>();
        timerOn = true;
        isWalking = true;
      
    }

    private void Update() {
        Action();
        AnimalTimer();

    }

    private void FixedUpdate() {
       
        Move();

      
    }

    public void Distance(){

    }


    public void Action(){
       if(isWalking) {
            MoveTimer();

       }
       else{
            PauseTimer();

       }
       if(timeToProduce){
        Produce();
       }
    }


    public void Move(){  

       if(isWalking){
            speed = walkSpeed;
            animator.SetBool("Walking", true);
            rigidbody.MovePosition(transform.position + transform.forward*speed);
       }
       else{
            animator.SetBool("Walking", isWalking);
            speed = 0f;
            rigidbody.MovePosition(transform.position);

       }

    }


    public void AnimalTimer(){
        time -= Time.deltaTime;

    }

    public void MoveTimer(){
        if(timerOn){
            time = moveTime;
            timerOn = false;

        }

        if(time<0){
            isWalking = false;
            timerOn = true;

        }
    }

    public void PauseTimer(){
        if(timerOn){
            time = pauseTime;
            timerOn = false;

        }
        
        //time -= Time.deltaTime;
        if(time<0){
            isWalking = true;
            timeToProduce = true;
            timerOn = true;

        }
    }

    public void ProduceTimer(){

    }

    

    void Rotate(){
        if(isWalking){
            Vector3 rotation = Vector3.Lerp(transform.eulerAngles, rotateDirection, 0.01f);
            rigidbody.MoveRotation(Quaternion.Euler(rotation));
        }
    }



   
    //동물 종류에 알맞게 생산품 생성
    public void Produce(){
       switch(animalType){
            case AnimalType.HEN:
            Debug.Log("알 생산!");
            break;

            case AnimalType.PIG:
            Debug.Log("고기 생산!");

            break;

            case AnimalType.COW:
            Debug.Log("우유 생산!");

            break;            
        }
        timeToProduce = false;
    }


    private void OnCollisionEnter(Collision other) {
        //회전
        Debug.Log("충돌!");
    }
         
}
