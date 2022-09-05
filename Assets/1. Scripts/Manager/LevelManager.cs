using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{

    public Button questButton;
    public int levelNum;
    public int questNum = 2;

    public LevelMap[] levelMap;
    public int goalEgg;
    public int goalHam;
    public int goalMilk;

    private BarnButtonChange barnBC;

    public QuestBox[] questBox;
   // public QuestBox questCheck;

    private void Start() {
       
    }
  


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
       // Debug.Log()

    }

    public void GameStart(){
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

        for(int i =0; i<questNum;i++){
            questBox[i].ProductNum();
        }

    }


    public void QuestsComplete(){
        
        for(int i =0; i<questNum;i++){
            if(questBox[i].check.activeSelf == true){
                Debug.Log("Quest Complete!");
                levelMap[levelNum -1].LevelDone();

                levelNum += 1;

            }

        }

    }

    public void QuestText(){
        
    }






}
