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

    private void Start() {
        min = (int)totalSec / 60;
        sec = (int)totalSec % 60;
        goalTimeText.text = string .Format("{0:D2}:{1:D2}", min, sec);
 
    }

    private void Update() {
        GameTimerUI();
        GameTimer();
        
    }

    void GameTimerUI(){
        timeText.text = string .Format("{0:D2}:{1:D2}", min, sec);


    }


    public void GameTimer(){
        totalSec -= Time.deltaTime;
        min = (int)totalSec / 60;
        sec = (int)totalSec % 60;
        if(totalSec < 0){
            totalSec = 0;
        }

    }

    public void GameOver(){

    }
}
