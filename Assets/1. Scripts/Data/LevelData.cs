using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "Level/LevelData")]
public class LevelData : ScriptableObject
{

    public int levelNum;
    public float goalSeconds;

    [Header("GoalProduct")]

    public int goalEgg;
    public int goalHam;
    public int goalMilk;

    public int goalNum;
    
    
}




