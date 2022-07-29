using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StorageSlotUnit : MonoBehaviour {


    public GameObject SellUI;
    public Button Slot;

    
    public Image itemImage;

    public CropData curData;
   // public Image itemImage;

    public void AddItem(CropData data){
        curData = data;
        itemImage.sprite = data.icon;
        itemImage.enabled = true;
    }

    public void ResetItem(){
        curData = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }

    public void SellUIOpen(){
        if(curData != null){
          SellUI.SetActive(true);

        }    
    }

    
    public void SellUICancel(){
        SellUI.SetActive(false);
    }

    public void SellItem(){
       FinanceManager.Instance.curMoney = FinanceManager.Instance.startMoney + curData.sellingPrice;
        ResetItem();
        //금액 추가.

    }
    
    
    
}