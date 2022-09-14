using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StorageSlotUnit : MonoBehaviour {


    public GameObject SellUI;
    public Button Slot;

    
    public Image itemImage;

    public ItemData curData;
   
   public int index = 0;

    public void AddItem(ItemData data){
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
        FinanceManager.Instance.curMoney = FinanceManager.Instance.curMoney + curData.sellingPrice;
        if(StorageManager.Instance.itemList[index].itemType == ItemData.ItemType.CROP){
            CookManager.Instance.cropList.Remove((CropData)StorageManager.Instance.itemList[index]);

        }
        else if(StorageManager.Instance.itemList[index].itemType == ItemData.ItemType.MATERIAL){
            CookManager.Instance.matList.Remove((MaterialData)StorageManager.Instance.itemList[index]);

        }
        else if(StorageManager.Instance.itemList[index].itemType == ItemData.ItemType.COAL){
            CookManager.Instance.coalList.Remove((CoalData)StorageManager.Instance.itemList[index]);
            CookManager.Instance.coalNum -= 1;

        }
        StorageManager.Instance.RemoveNum(StorageManager.Instance.itemList[index]);

        SellUI.SetActive(false);
    }


   
    
}