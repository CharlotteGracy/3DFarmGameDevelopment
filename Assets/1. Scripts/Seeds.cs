using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    //TODO: 씨앗이 자라는 과정 구현

    //물을 뿌리고 시간이 지나면 다음 Step으로 넘어감


    public GameObject SeedGroup;
    public GameObject PlantLevel1Group;
    public GameObject PlantLevel2Group;
    public GameObject PlantLevel3Group;


    public void PlantedSeed(){

        SeedGroup.SetActive(true);

    }

    public void PlantLevel1(){

        SeedGroup.SetActive(false);
        PlantLevel1Group.SetActive(true);

    }

    public void PlantLevel2(){

        PlantLevel1Group.SetActive(false);
        PlantLevel2Group.SetActive(true);

    }
    public void PlantLevel3(){

        PlantLevel3Group.SetActive(true);
        PlantLevel2Group.SetActive(false);

    }

    public void Crops(){
        //Cabbage, Carrot, Sunflower, Wheat, Watermelon, Pumpkin, 
        //Apple, Orange, Palm,


    }

  

}
