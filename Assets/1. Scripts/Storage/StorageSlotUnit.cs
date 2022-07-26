using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageSlotUnit : MonoBehaviour
{

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

    
}
