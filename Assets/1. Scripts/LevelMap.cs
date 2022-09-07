using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    public Material lockedMat;
    public Material currentMat;
    public Material unlockedMat;
    Renderer levelColor;
    public int levelNum;
    
    public LevelData levelData;
    private GameSceneButtonChange gameSceneBC;


    private void Start() {
        levelColor = gameObject.GetComponent<Renderer>();

    }


    private void Awake() {
        
        gameSceneBC = GameObject.Find("GameManager").GetComponent<GameSceneButtonChange>();

    }


    private void OnMouseDown() {
        if (this.levelColor.sharedMaterial != lockedMat){
            //해당 레벨로 진입
            Debug.Log("레벨을 시작합니다!");
            LevelManager.Instance.levelNum = levelNum;

            LevelManager.Instance.GameStart();
            gameSceneBC.BarnOn();
        }

        if(this.levelColor.sharedMaterial == lockedMat){
            Debug.Log("Locked!");

        }
        else{
        }



        
    }

    public void LevelDone(){
        levelColor.material = unlockedMat;
    }

    public void CurLevel(){
        levelColor.material = currentMat;

    }

    
   
}
