﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FinanceManager : Singleton<FinanceManager>
{


    public UnityAction OnChangeMoney;

    public Text moneyText;

    private int startMoney = 500;

    private int _money;
    public int curMoney{
        get{
            return _money;
        }
        set{
            _money = value;
            OnChangeMoney?.Invoke();
            moneyText.text = _money.ToString();
        }
    }


    //TODO: 물품의 금액과 현재 가진 돈을 비교하여 살 수 있는지 없는지 판단
    //  public bool canBuy;
    

   // public CropData cropData;
    private void Start() {
        curMoney = startMoney;
    }



    private void Awake() {
        _instance = this;
    }



    public void NoMoney(){
        //금액 부족시 비활성화
        Debug.Log("금액이 부족합니다!");
        //NotEnoughMoney

    }

    





}
