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
    public enum AnimalState { Idle, Walk }
    private	AnimalState	animalState;


    public float walkSpeed = 0.001f;
    private float speed;
    
    public float moveTime;
    public float pauseTime;
    [SerializeField]
    private float time;
    public Vector3 rotateDirection;

    int rotateNum = 1;



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
    new private Rigidbody rigidbody;
    //[SerializeField]
    private Animator animator;
    new private Collider collider;

    
 
    // Start is called before the first frame update
    private void Start() {
        animator = this.gameObject.GetComponent<Animator>();
        collider = this.gameObject.GetComponent<CapsuleCollider>();
        timerOn = true;
        isWalking = true;
      
    }
    private void Awake() {
        ChangeState(AnimalState.Idle);

    }

    private void Update() {
       

    }

    private void FixedUpdate() {
        Move();
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

    void RotateButton(){
        //아래는 1, 왼쪽은 2, 오른쪽은 3, 위쪽은 4

        switch(rotateNum){
            case 1:
            rotateDirection = new Vector3 (0,0,0);
            break;

            case 2:
            rotateDirection = new Vector3 (0,90,0);
            break;

            case 3:
            rotateDirection = new Vector3 (0,180,0);
            break;

            case 4:
            rotateDirection = new Vector3 (0,270,0);
            break;

        }
    }

   
    
    void Rotate(){
       int curRotateNum;
        curRotateNum = rotateNum;

        rotateNum = Random.Range(1, 5);

        while(curRotateNum == rotateNum){
            rotateNum = Random.Range(1, 5);

        }
        RotateButton();
        Vector3 rotation = Vector3.Lerp(transform.eulerAngles, rotateDirection, 100f);
        rigidbody.MoveRotation(Quaternion.Euler(rotation));
        
    }

    //동물 종류에 알맞게 생산품 생성
    public void Produce(){
       GameObject newProduction;

       switch(animalType){
            case AnimalType.HEN:
            Debug.Log("알 생산!");
            newProduction = Instantiate(egg);
            newProduction.transform.position = this.gameObject.transform.position + new Vector3(0, 0.1f, 0);
            break;

            case AnimalType.PIG:
            Debug.Log("고기 생산!");
            newProduction = Instantiate(ham);
            newProduction.transform.position = this.gameObject.transform.position + new Vector3(0, 0.1f, 0);
            break;

            case AnimalType.COW:
            Debug.Log("우유 생산!");
            newProduction = Instantiate(milk);
            newProduction.transform.position = this.gameObject.transform.position + new Vector3(0, 0.1f, 0);
            break;            
        }
        timeToProduce = false;
    }


    private void OnCollisionEnter(Collision other) {
        //회전
        Debug.Log("충돌!");
        Rotate();
        
    }
        //유한상태
        //idle, move
        //코루틴 상태 패턴
    	private void ChangeState(AnimalState newState){
		// 이전 상태의 코루틴 종료
		StopCoroutine(animalState.ToString());
		// 새로운 상태로 변경
		animalState	= newState;
		// 현재 상태의 코루틴 실행
		StartCoroutine(animalState.ToString());
	}

	private IEnumerator Idle(){
		isWalking = false;
		yield return new WaitForSeconds(pauseTime);
        Produce();
		ChangeState(AnimalState.Walk);
	}

	private IEnumerator Walk(){
		isWalking = true;
		yield return new WaitForSeconds(moveTime);
		ChangeState(AnimalState.Idle);
	}
         
}
