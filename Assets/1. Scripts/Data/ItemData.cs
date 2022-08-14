using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ItemData", menuName = "StorageItem/ItemData")]

public class ItemData : ScriptableObject
{
    new public string name;
    public string Description;
   // public CropType cropType;


    public int sellingPrice;
    
    
    [Header("Item UI")]
    public Sprite icon;
    

}