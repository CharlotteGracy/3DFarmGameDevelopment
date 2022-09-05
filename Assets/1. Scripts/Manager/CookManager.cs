using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookManager : Singleton<CookManager>
{
    public CropData cropData;
    public MaterialData materialData;
    public ItemData itemData;
    public FoodData[] foodDatas;
    public int i =0;

    public List<CropData> cropList = new List<CropData>();
    public List<MaterialData> matList = new List<MaterialData>();

    private void Awake() {
        _instance = this;
    }


    //StorageManager의 ItemList에서 cropdata만 Croplist에 집어넣는다.
    public void ClassifyDatas(){


        for(int i =0; i<StorageManager.Instance.maxCount; i++){
           // if (StorageManager.Instance.itemList[i] is CropData){

            //}
            if(StorageManager.Instance.itemList[i].itemType == ItemData.ItemType.CROP){
                cropList.Add((CropData)StorageManager.Instance.itemList[i]);

            }
            else if(StorageManager.Instance.itemList[i].itemType == ItemData.ItemType.MATERIAL){
                matList.Add((MaterialData)StorageManager.Instance.itemList[i]);
            }
            else{

            }
        }
       


    }

}
