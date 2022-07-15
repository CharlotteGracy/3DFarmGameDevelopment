using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FinanceManager : Singleton<FinanceManager>
{


    public UnityAction OnChangeMoney;

    



    public Text moneyText;

    private int startMoney = 500;


    public void NoMoney(){
        //금액 부족시 비활성화


    }



}
