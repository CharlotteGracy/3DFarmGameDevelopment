using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;
//using Debug = UnityEngine.Debug;




public class FieldAction : MonoBehaviour
{


    public Renderer[] rend;
    

  //  private PlayerMover pm;
    public Material driedField;
    public Material wetField;
    public GameObject seed;


    private void Start()
    {
      
    }


    private void Awake()
    {
      //  pm = GameObject.Find("Player").GetComponent<PlayerMover>();
       // toolSwitch = GameObject.Find("GameManager").GetComponent<GameSceneButtonChange>();

    }


    public void ShovelUsed(){

        Debug.Log("삽 사용");

    }

    public void SeedUsed(){
        Debug.Log("씨앗 사용");

        //씨앗 Prefab을 각 Cube에 추가



    }



    public void WateringCanUsed(){
      Debug.Log("물뿌리개 사용");

      //  rend.material.EnableKeyword("");


      //rend.material.SetTexture("PlowedGround_Mat",dFieldTexture);
     // rend.material.SetTexture("PlowedGround_Wet_Mat", wFieldTexture);

      //TODO: 젖은 땅 material을 넣어줄 수 있도록 작성
//      gameObject.GetComponent<Renderer>().material = 

      for(int i = 0; i < rend.Length; i++)
      {
        rend[i].material = wetField;
      }

    //  Stopwatch timeCount = new Stopwatch();
    //  timeCount.Start();


      Evaporated();


    }

    //시간이 흐르면 땅이 마르는 함수
    public void Evaporated(){

      StartCoroutine(KeepingWet());


 
    }


    IEnumerator KeepingWet(){
      Debug.Log("젖었음");

      yield return new WaitForSecondsRealtime(2f);
    }





//TODO: 플레이어가 스페이스 바를 눌렀을 때 그 행동에 상응하는 기능이 구현되도록


    
   
}
