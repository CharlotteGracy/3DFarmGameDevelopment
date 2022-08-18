using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CropType{CARROT, CABBAGE, WATERMELON, PUMPKIN, SUNFLOWER, WHEAT,};

[CreateAssetMenu(fileName = "CropData", menuName = "StorageItem/ItemData/CropData")]

public class CropData : ItemData
{
   // new public string name;
    public int Price;

    public CropType cropType;

    
  


}
