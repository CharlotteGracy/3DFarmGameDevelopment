using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public Message b_messageText;
    public Button questButton;
    public int levelNum;
    public int maxLevelNum;
    public int questNum = 3;
    public int goalNum;

    public LevelMap[] levelMap;
    public int goalEgg;
    public int goalHam;
    public int goalMilk;

    private BarnButtonChange barnBC;

    public QuestBox[] questBox;
   // public QuestBox questCheck;

    private void Awake() {
        _instance = this;        
        barnBC = GameObject.Find("BarnGameManager").GetComponent<BarnButtonChange>();
    }


    public void LevelOpen(){
        questButton.interactable = true;
    }

    public void LevelTimeSet(){
        barnBC.barnTimer.totalSec = levelMap[levelNum - 1].levelData.goalSeconds;
        barnBC.barnTimer.GoalTimeUI();
        barnBC.barnTimer.timerOn = true;
       

    }

    public void GameStart(){

        ResetLevel();
        //타이머 스타트
        LevelTimeSet();
        //퀘스트 설정 스타트
        SetQuest();

        

    }

    public void SetQuest(){

        /*
        if(questNum == 1){
            questBox[0].SetActive(true);
            questBox[1].SetActive(false);
            questBox[2].SetActive(false);
        }
        else if(questNum == 2){
            questBox[0].SetActive(true);
            questBox[1].SetActive(true);
            questBox[2].SetActive(false);

        }
        else if(questNum == 3){
            questBox[0].SetActive(true);
            questBox[1].SetActive(true);
            questBox[2].SetActive(true);
        }

        */

        goalEgg = levelMap[levelNum - 1].levelData.goalEgg;
        goalHam = levelMap[levelNum - 1].levelData.goalHam;
        goalMilk = levelMap[levelNum - 1].levelData.goalMilk;

        goalNum = levelMap[levelNum - 1].levelData.goalNum;

        for(int i =0; i<questNum;i++){
            questBox[i].ProductNum();
        }

    }


    public void QuestsComplete(){
        
        for(int i =0; i<goalNum;i++){

            if(questBox[i].check.activeSelf == false)
                return;

        }
        
        barnBC.barnTimer.timerOn = false;
        DestroyAnimals();
        DestroyProducts();

        b_messageText.LevelComplete();
        levelMap[levelNum -1].LevelDone();
        
        //level 수를 하나 올려주고 해당 레벨맵의 색을 CurrentMaterial로 변경.
        levelNum += 1;
        levelMap[levelNum - 1].CurLevel();
        StartCoroutine(GoToMap());


    }

    public void DestroyAnimals(){
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        int animalCount = AnimalSaleManager.Instance.henNum + AnimalSaleManager.Instance.pigNum + AnimalSaleManager.Instance.cowNum;
        for(int i = 0; i < animalCount;i++){
            Destroy(animals[i]);
            AnimalSaleManager.Instance.henNum = 0;
            AnimalSaleManager.Instance.pigNum = 0;
            AnimalSaleManager.Instance.cowNum = 0;


        }

    }

    public void DestroyProducts(){
        GameObject[] products = GameObject.FindGameObjectsWithTag("Product");
        for(int i = 0; i<products.Length;i++){
            Destroy(products[i]);
        }

    }





    public void ResetLevel(){
        for(int i = 0; i < questNum;i++){
            questBox[i].QuestReset();
        }
        BarnCountManager.Instance.ResetCounts();

    }


    IEnumerator GoToMap(){
        yield return new WaitForSeconds(3f);
        barnBC.GoBackToMap();

    }






}
