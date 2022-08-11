using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoalTimer : MonoBehaviour
{


   public float totalSec;

    public int sec;
    public int min;
    public bool timerActive = true;
    public TMP_Text timeText;

    public GameObject carriageCoal;




    private void Update() {
        TimerWork();
        TimerUI();
       
    }


    private void Start() {
        timeText.text = min + " : " + sec;
        if(min > 0){
            totalSec += min*60;

        }
        if(sec>0){
            totalSec += sec;

        }
    }


    void TimerUI(){
        timeText.text = string .Format("{0:D2}:{1:D2}", min, sec);

    }


    public void CoalMinable(){
        if(min == 0 && sec == 0){
            Debug.Log("Coal is Ready!");
            carriageCoal.SetActive(true);
            timeText.faceColor = Color.red;
        }
    }


    void TimerWork(){
        if(timerActive == true){
            Timer();
        }
        else{
        }
    }


    public void Timer(){
        totalSec -= Time.deltaTime;
        min = (int)totalSec / 60;
        sec = (int)totalSec % 60;
        if(totalSec < 0){
            totalSec = 0;
            CoalMinable();
            timerActive = false;
        }
    }



  





    
}
