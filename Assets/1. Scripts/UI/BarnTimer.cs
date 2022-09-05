using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarnTimer : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text goalTimeText;

    public float totalSec;
    public float goalSec;
    public int min;
    public int sec;
    public bool timerOn;

    private void Start() {

    }

    private void Update() {
        GameTimerUI();
        GameTimerWork();
        
    }

    public void GoalTimeUI(){
        min = (int)totalSec / 60;
        sec = (int)totalSec % 60;
        goalTimeText.text = string .Format("{0:D2}:{1:D2}", min, sec);
 
    }

    void GameTimerUI(){
        min = (int)totalSec / 60;
        sec = (int)totalSec % 60;
        timeText.text = string .Format("{0:D2}:{1:D2}", min, sec);


    }

    void GameTimerWork(){
        if(timerOn){
            GameTimer();
        }
        else{

        }
    }


    public void GameTimer(){
        totalSec -= Time.deltaTime;

        if(totalSec < 0){
            totalSec = 0;
        }

    }

    public void ResetTimer(){
        totalSec = goalSec;
    }

    public void GameOver(){

    }
}
