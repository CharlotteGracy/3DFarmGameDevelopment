using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MateralType{FLOUR, OIL,};

[CreateAssetMenu(fileName = "MaterialData", menuName = "StorageItem/ItemData/MaterialData")]

public class MaterialData : ItemData
{
    public MateralType materalType;
    
}
