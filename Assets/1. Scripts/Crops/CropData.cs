using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CropType{CARROT, CABBAGE, WATERMELON, PUMPKIN, APPLE, ORANGE, COCONUT, SUNFLOWER,};

[CreateAssetMenu(fileName = "CropData", menuName = "Crop/CropData")]

public class CropData : ScriptableObject
{
    new public string name;
    public string Description;
    public CropType cropType;


    public int sellingPrice;
    
    


    [Header("Crop UI")]
    public Sprite icon;
    public GameObject cropObject;



}
