using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSlotUI : MonoBehaviour
{
    StorageSlotUnit[] storageSlots;
    //Vector3 mousePos, transPos, targetPos;
    int SlotmaxCount;

  

    public void UpdateUI(){

        storageSlots = GetComponentsInChildren<StorageSlotUnit>();

        List<ItemData> list = StorageManager.Instance.itemList;
        SlotmaxCount = StorageManager.Instance.maxCount - 1;

        for(int i = 0; i<storageSlots.Length; i++){
            int count = list.Count;
            if(i<count){
                storageSlots[SlotmaxCount - i].AddItem(list[i]);
            }
            else{
                storageSlots[SlotmaxCount - i].ResetItem();
            }
        }
    }

}
