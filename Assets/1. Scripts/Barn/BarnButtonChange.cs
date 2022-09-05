using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnButtonChange : MonoBehaviour
{

    public GameObject barnCanvas;
    public GameObject gameCanvas;
    public GameObject mapCanvas;
   // public GameObject playerCam;
    public GameObject barnCam;
    public GameObject playerCam;
    public GameObject mapCam;

    
    public GameObject barnExitUI;
    public GameObject mapExitUI;

    public BarnTimer barnTimer;
    

    public void BarnExit(){
       barnExitUI.SetActive(true);
       barnTimer.timerOn = false;

    }

    public void MapExit(){
        mapExitUI.SetActive(true);
        barnTimer.timerOn = false;
    }

    public void ExitNo(){
        barnExitUI.SetActive(false);
        mapExitUI.SetActive(false);
        barnTimer.timerOn = true;

    }

    public void ExitYes(){
        Debug.Log("농장으로 돌아갑니다..");
        barnCam.SetActive(false);
        mapCam.SetActive(false);
        playerCam.SetActive(true);
        barnCanvas.SetActive(false);
        mapCanvas.SetActive(false);
        gameCanvas.SetActive(true);

        barnExitUI.SetActive(false);
        mapExitUI.SetActive(false);

    }


}
