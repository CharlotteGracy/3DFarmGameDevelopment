using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSlotUI : MonoBehaviour
{
    StorageSlotUnit[] storageSlots;

    private void Update() {
      //  UpdateUI();
    }

    public void UpdateUI(){

        storageSlots = GetComponentsInChildren<StorageSlotUnit>();

        List<CropData> list = StorageManager.Instance.cropList;

        for(int i = 0; i<storageSlots.Length; i++){
            int count = list.Count;
            if(i<count){
                storageSlots[i].AddItem(list[i]);
            }
            else{
                storageSlots[i].ResetItem();
            }
        }
    }
    
}
