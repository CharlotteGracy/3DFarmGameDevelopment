using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FinanceManager : Singleton<FinanceManager>
{


    public UnityAction OnChangeMoney;

    public Text[] moneyTexts;

    private int startMoney = 5000;

    private int _money;
    public int curMoney{
        get{
            return _money;
        }
        set{
            _money = value;
            OnChangeMoney?.Invoke();

            for(int i =0; i<moneyTexts.Length;i++){
                moneyTexts[i].text = _money.ToString();
            }    
            if(_money >= 200){
                LevelManager.Instance.LevelOpen();
            }
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


}
