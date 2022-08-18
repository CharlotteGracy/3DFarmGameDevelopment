using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MateralType{FLOUR, OIL, SAUCE,};

[CreateAssetMenu(fileName = "MaterialData", menuName = "StorageItem/ItemData/MaterialData")]

public class MaterialData : ItemData
{

   // public int Price;

    public MateralType materalType;
    
}
