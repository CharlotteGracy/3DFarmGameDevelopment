using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : Singleton<StoreManager>
{
    //[Header("Item Buttons")]

    public ItemData data;
    public CoalData coalData;

    [Header("Materials")]
    public MaterialData flourData;
    public MaterialData oilData;
    public MaterialData sauceData;


    public void BuyCarrot(){
        data = SeedButtonManager.Instance.carrotData;
        GetItemInStroage();
        

    }

    public void BuyCabbage(){
        data = SeedButtonManager.Instance.cabbageData;
        GetItemInStroage();

    }

    public void BuyWatermelon(){
        data = SeedButtonManager.Instance.watermelonData;
        GetItemInStroage();

    }

    public void BuyPumpkin(){
        data = SeedButtonManager.Instance.pumpkinData;
        GetItemInStroage();

    }

    public void BuySunflower(){
        data = SeedButtonManager.Instance.sunflowerData;
        GetItemInStroage();

    }

    public void BuyWheat(){
        data = SeedButtonManager.Instance.wheatData;
        GetItemInStroage();

    }

    public void BuyFlour(){
      data = flourData;
      GetItemInStroage();
    }

    public void BuyOil(){
        data = oilData;
        GetItemInStroage();

    }
    public void BuySauce(){
        data = sauceData;
        GetItemInStroage();

    }
    public void BuyCoal(){
        data = coalData;
        GetItemInStroage();

    }

    public void NoMoney(){
        Debug.Log("금액이 부족합니다!");
        StorageManager.Instance.messageText.NotEnoughMoney();

    }


    public void GetItemInStroage(){
        if(FinanceManager.Instance.curMoney < data.price){
            NoMoney();
        }
        else{
            if(StorageManager.Instance.AddNum(data) == false){
            }
            else{
                FinanceManager.Instance.curMoney = FinanceManager.Instance.curMoney - data.price;
            
            }     
        }

   
    }


}
