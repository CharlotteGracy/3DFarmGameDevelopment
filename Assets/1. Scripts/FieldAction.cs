﻿using System.Collections;
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
    public GameObject Watermelons;
    public GameObject Pumpkins;
    public GameObject Sunflowers;
    public GameObject Wheats;

    public Renderer[] rend;

    [Header("Material")]

    public Material driedField;
    public Material wetField;
    public Material diggedField;
    public GameObject seed;

    [Header("MessageText")] 
    public Message messageText;



    private bool seedPlanted;
    public bool shovelUsed;
    
    public bool grownUp;
    public bool wet = false;

    public CropData cropData;

    public Text harvestMessage;

    

    
    public void ShovelUsed(){

        Debug.Log("삽 사용");
        if(wet == true){

        }
        else{
          //씨앗 뿌리기 활성화
          StartCoroutine(Digged());
          shovelUsed = true;          
        }
    }

    public void SeedUsed(){
        //Debug.Log(gameObject.name);
        Debug.Log("씨앗 사용");
        if(shovelUsed == false){
          Debug.Log("Didn't ready for seeds!");
          messageText.NoShovelUsed();

        }
        else{
          if(seedPlanted == true){
            Debug.Log("Already Planted!");
            messageText.AlreadyPlanted();
          }
          else{
            cropData = SeedButtonManager.Instance.data;
          }

          if(cropData == null){
            Debug.Log("씨앗이 선택되지 않았습니다!");
            messageText.NoSeedSelected();

          }
          else{
            if(seedPlanted == true){
              Debug.Log("Already Planted!");
              messageText.AlreadyPlanted();
            }
            else{
              PlantedSeed();
              seedPlanted = true;
              StartCoroutine(NormalField());
            }
          }
        }
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
    Debug.Log("땅이 파입니다!");
    for(int i = 0; i < rend.Length; i++){
      rend[i].material = diggedField;
    }

    yield return new WaitForSecondsRealtime(5f);
  }
  IEnumerator NormalField(){

    yield return null;
    for(int i = 0; i < rend.Length; i++){
      rend[i].material = driedField;
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

            case CropType.WATERMELON:
            Watermelons.SetActive(true);
            break;

            case CropType.PUMPKIN:
            Pumpkins.SetActive(true);
            break;

            case CropType.SUNFLOWER:
            Sunflowers.SetActive(true);
            break;

            case CropType.WHEAT:
            Wheats.SetActive(true);
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

        case CropType.WATERMELON:
        PlantsOff();
        Watermelons.SetActive(false);
        break;

        case CropType.PUMPKIN:
        PlantsOff();
        Pumpkins.SetActive(false);
        break;

        case CropType.SUNFLOWER:
        PlantsOff();
        Sunflowers.SetActive(false);
        break;

        case CropType.WHEAT:
        PlantsOff();
        Wheats.SetActive(false);
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
      
      messageText.CropHarvested();
      CropsOff(cropData);
      cropData = null;
      seedPlanted = false;
      grownUp = false;
      wet = false;
      shovelUsed = false;
      
    }

    public void HarvestMessage(){
      Debug.Log("Press SPACE To Harvest");
    }







//TODO: 플레이어가 스페이스 바를 눌렀을 때 그 행동에 상응하는 기능이 구현되도록


    
   
}
