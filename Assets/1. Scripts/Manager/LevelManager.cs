using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{

    public Button questButton;
    public int questNum;

    public GameObject[] questBox;


    private void Awake() {
        _instance = this;
    }



    public void LevelOpen(){
        questButton.interactable = true;

    }

    public void SetQuest(){
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
    }






}
