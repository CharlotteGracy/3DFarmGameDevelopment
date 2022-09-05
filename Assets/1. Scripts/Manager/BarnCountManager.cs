using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnCountManager : Singleton<BarnCountManager>
{

    public int eggNum;
    public int hamNum;
    public int milkNum;
    //private Observer questBox;
    

    private void Awake() {
        _instance = this;
    }

    public void AddObserver(Observer observer){
        

    }

    public void RemoveObserver(Observer observer){

    }

    public void Notify(){

    }

}
