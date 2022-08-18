using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    public Material lockedMat;
    public Material currentMat;
    public Material unlockedMat;
    Renderer levelColor;
    
    public LevelData levelData;

    private void Start() {
        levelColor = gameObject.GetComponent<Renderer>();
    }


    private void OnMouseDown() {
        if (levelColor.material != unlockedMat){
            //해당 레벨로 진입

        }
        else{
            Debug.Log("Unlocked!");
        }



        
    }

    
   
}
