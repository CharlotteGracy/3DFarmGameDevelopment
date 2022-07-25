using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;
//using Debug = UnityEngine.Debug;
using UnityEngine.UI;




public class FieldAction : MonoBehaviour
{

    [Header("SeedToPlant")]

    public GameObject SeedGroup;
    public GameObject PlantLevel1Group;
    public GameObject PlantLevel2Group;
    public GameObject PlantLevel3Group;

    [Header("Crops")]
    public GameObject Carrots;
    public GameObject Cabbages;

    public Renderer[] rend;
  //  private PlayerMover pm;
    public Material driedField;
    public Material wetField;
    public GameObject seed;

   // private Seeds seeds;

    private bool seedPlanted;
    private bool shovelUsed;
    
    public bool grownUp;
    public bool wet = false;

    public CropData cropData;

    public Text harvestMessage;

    


    private void Awake()
    {
     // seeds = GetComponent<Seeds>();
    }

    
    public void ShovelUsed(){

        Debug.Log("삽 사용");
        //씨앗 뿌리기 활성화
        shovelUsed = true;

    }

    

    public void SeedUsed(){
        Debug.Log(gameObject.name);
        Debug.Log("씨앗 사용");
        cropData = SeedButtonManager.Instance.data;


        if(cropData == null){
          Debug.Log("씨앗이 선택되지 않았습니다!");

        }
        else{
          if(seedPlanted == true){
              Debug.Log("Already Planted!");
            }
            else{
              PlantedSeed();
              seedPlanted = true;

            }
        }

        //씨앗 Prefab을 각 Cube에 추가

 
    }



    public void WateringCanUsed(){
      Debug.Log("물뿌리개 사용");  
      //씨앗에 물 뿌리면 다음 단계로 진행

      StartCoroutine(Evaporated());

      
      if(seedPlanted == true && wet == false){
        wet = true;
        StartCoroutine(PlantGrow());
      }

      
     
     

    }

  IEnumerator Digged(){
    yield return new WaitForSecondsRealtime(5f);
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

    public void PlantedSeed(){

        SeedGroup.SetActive(true);
        PlantLevel1Group.SetActive(false);
        PlantLevel2Group.SetActive(false);
        PlantLevel3Group.SetActive(false);
    }

    public void PlantLevel1(){

        SeedGroup.SetActive(false);
        PlantLevel1Group.SetActive(true);
        PlantLevel2Group.SetActive(false);
        PlantLevel3Group.SetActive(false);
    }

    public void PlantLevel2(){

        SeedGroup.SetActive(false);
        PlantLevel1Group.SetActive(false);
        PlantLevel2Group.SetActive(true);
        PlantLevel3Group.SetActive(false);

    }
    public void PlantLevel3(){

        SeedGroup.SetActive(false);
        PlantLevel1Group.SetActive(false);
        PlantLevel2Group.SetActive(false);
        PlantLevel3Group.SetActive(true);

    }

    public void PlantsOff(){
        SeedGroup.SetActive(false);
        PlantLevel1Group.SetActive(false);
        PlantLevel2Group.SetActive(false);
        PlantLevel3Group.SetActive(false);    
        }

   

    public void CropsOn(CropData cropData){
        //Cabbage, Carrot, Sunflower, Wheat, Watermelon, Pumpkin, 
        //Apple, Orange, Palm,
//        Debug.Log(cropData);

        switch(cropData.cropType){
            case CropType.CARROT:
            Carrots.SetActive(true);
            break;

            case CropType.CABBAGE:
            Cabbages.SetActive(true);
            break;
        }
    }

    public void CropsOff(CropData cropData){
      switch(cropData.cropType){
        case CropType.CARROT:
        PlantsOff();
        Carrots.SetActive(false);
        break;

        case CropType.CABBAGE:
        PlantsOff();
        Cabbages.SetActive(false);
        break;
      }
    }

    IEnumerator PlantGrow(){

      yield return new WaitForSecondsRealtime(5f);
      PlantLevel1();
      yield return new WaitForSecondsRealtime(5f);
      PlantLevel2();
      yield return new WaitForSecondsRealtime(5f);
      PlantLevel3();
      yield return new WaitForSecondsRealtime(5f);
      PlantsOff();
      CropsOn(cropData);
      grownUp = true;
    }

    public void Harvested(){
      Debug.Log("다 자란 작물을 수확합니다!");
     // PlantsOff();
      CropsOff(cropData);
      cropData = null;
      seedPlanted = false;
      grownUp = false;
      wet = false;


    }

    public void HarvestMessage(){
      Debug.Log("Press SPACE To Harvest");
    }







//TODO: 플레이어가 스페이스 바를 눌렀을 때 그 행동에 상응하는 기능이 구현되도록


    
   
}
