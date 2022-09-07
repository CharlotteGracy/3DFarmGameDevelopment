using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : Singleton<StorageManager>
{

    public List<ItemData> itemList = new List<ItemData>();

    public StorageSlotUI storageSlotUI;
    public int maxCount = 9;
    public Message messageText;


    private void Awake() {
        _instance = this;
    }


    public bool AddNum(ItemData data){
        if(itemList.Count >= maxCount){
            messageText.FullStorage();
            return false;
        }
        else{
            itemList.Add(data); 
            storageSlotUI.UpdateUI();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            storageSlotUI.UpdateUI();
            CookManager.Instance.ClassifyDatas(data);
            return true;
        }
    }

    public void RemoveNum(ItemData data){ 
        itemList.Remove(data);
        storageSlotUI.UpdateUI();
    }


}
