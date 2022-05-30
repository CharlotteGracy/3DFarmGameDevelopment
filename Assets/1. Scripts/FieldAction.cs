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
      StartCoroutine(KeepingWet());

 

    }

    //시간이 흐르면 땅이 마르는 함수
    


    public void Evaporated(){
      for(int i = 0; i < rend.Length; i++)
      {
        rend[i].material = driedField;
      }
    }


    IEnumerator KeepingWet(){
      Debug.Log("젖었음");

      for(int i = 0; i < rend.Length; i++)
      {
        rend[i].material = wetField;
      }

      yield return new WaitForSeconds(5f);

      for(int i = 0; i < rend.Length; i++)
      {
        rend[i].material = driedField;
      }      
    }





//TODO: 플레이어가 스페이스 바를 눌렀을 때 그 행동에 상응하는 기능이 구현되도록


    
   
}
