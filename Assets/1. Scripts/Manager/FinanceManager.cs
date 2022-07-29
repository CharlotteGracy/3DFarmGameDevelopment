using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FinanceManager : Singleton<FinanceManager>
{


    public UnityAction OnChangeMoney;

    public Text moneyText;

    public int startMoney = 500;
    public int curMoney;

   // public CropData cropData;
    private void Start() {
        curMoney = startMoney;
    }


    public void NoMoney(){
        //금액 부족시 비활성화
        Debug.Log("금액이 부족합니다!");
        //NotEnoughMoney

    }

    





}
