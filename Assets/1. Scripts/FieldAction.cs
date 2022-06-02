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

    private Seeds seeds;

    private bool seedPlanted;


    private void Awake()
    {
      seeds = GetComponent<Seeds>();
    }

    




    public void ShovelUsed(){

        Debug.Log("삽 사용");

        //씨앗 뿌리기 활성화

    }

    public void SeedUsed(){
        Debug.Log(gameObject.name);
        Debug.Log("씨앗 사용");

        //씨앗 Prefab을 각 Cube에 추가

        if(seedPlanted == true){
          Debug.Log("Already Planted!");
        }
        else{
          seeds.PlantedSeed();
          seedPlanted = true;

        }


 


//TODO: groundWet은 수확 이후에 false로 해준다

     




    }



    public void WateringCanUsed(){
      Debug.Log("물뿌리개 사용");  

      //씨앗에 물 뿌리면 다음 단계로 진행
      


      StartCoroutine(Evaporated());
     
     if(seedPlanted == true){
        StartCoroutine(PlantGrow());
      //  seedPlanted = false;
     }


    }

    


   


    IEnumerator Evaporated(){
      Debug.Log("젖었음");

      for(int i = 0; i < rend.Length; i++)
      {
        rend[i].material = wetField;
      }


      yield return new WaitForSecondsRealtime(5f);


      for(int i = 0; i < rend.Length; i++)
      {
        rend[i].material = driedField;
      }

      
    }

    

    IEnumerator PlantGrow(){

      yield return new WaitForSecondsRealtime(5f);
      seeds.PlantLevel1();
      yield return new WaitForSecondsRealtime(5f);
      seeds.PlantLevel2();
      yield return new WaitForSecondsRealtime(5f);
      seeds.PlantLevel3();

    }





//TODO: 플레이어가 스페이스 바를 눌렀을 때 그 행동에 상응하는 기능이 구현되도록


    
   
}
