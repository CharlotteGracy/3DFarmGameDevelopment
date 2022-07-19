using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : Singleton<PlantManager>
{
    public void RaisingCrop(CropData cropData){

        switch(cropData.cropType){
            case CropType.CARROT:
            break;

            case CropType.CABBAGE:
            break;
        }


    }
}
