using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageSlotUnit : MonoBehaviour
{


    public CropData curData;
    public Image itemImage;

    public void AddItem(CropData data){
        curData = data;
    }

    public void ResetItem(){
        curData = null;

        
    }

    
}
