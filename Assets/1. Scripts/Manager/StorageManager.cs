using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : Singleton<StorageManager>
{

    public List<CropData> cropList = new List<CropData>();
    public StorageSlotUI storageSlotUI;
    public int maxCount = 9;
    public Message messageText;


    private void Awake() {
        _instance = this;
    }


    public bool AddNum(CropData data){
        if(cropList.Count >= maxCount){
            messageText.FullStorage();
            return false;
        }
        else{
            cropList.Add(data); 
            storageSlotUI.UpdateUI();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            storageSlotUI.UpdateUI();
            return true;
        }
    }

    public void RemoveNum(CropData data){ 
        cropList.Remove(data);
        storageSlotUI.UpdateUI();
    }


}
