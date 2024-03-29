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
    public enum ItemType{CROP, COAL, MATERIAL, FOOD,};

    
    
    [Header("Item UI")]
    public Sprite icon;
    
    public int price;
    public ItemType itemType;

}