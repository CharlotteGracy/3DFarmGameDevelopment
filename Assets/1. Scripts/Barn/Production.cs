using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Production : MonoBehaviour
{

    //public UnityEvent OnProductGet;

    public enum ProductionType {EGG, HAM, MILK,};
    public float existTime;
    public ProductionType productionType;

    private void Update() {
        ExistTimer();
    }

    void ExistTimer(){
        existTime -= Time.deltaTime;

        if(existTime < 0){
            Destroy(this.gameObject);

        }
    }

    private void OnMouseDown() {
        Destroy(this.gameObject);
       int questNum;
       questNum = LevelManager.Instance.questNum;


        switch(productionType){
            case ProductionType.EGG:
            BarnCountManager.Instance.eggNum += 1;
            break;
            case ProductionType.HAM:
            BarnCountManager.Instance.hamNum += 1;
            break;
            case ProductionType.MILK:
            BarnCountManager.Instance.milkNum += 1;
            break;

        }
       for(int i = 0; i< questNum; i++){
            LevelManager.Instance.questBox[i].ProductNum();
       }
       LevelManager.Instance.QuestsComplete();


    }
}
