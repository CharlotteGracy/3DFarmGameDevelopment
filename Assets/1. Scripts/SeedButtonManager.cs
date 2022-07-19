using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedButtonManager : Singleton<SeedButtonManager>
{

    [Header("Data")]
    public CropData data;
    public CropData carrotData;
    public CropData cabbageData;

    [Header("Buttons")]
    public Button carrotButton;
    public Button cabbageButton;

    private void Start() {
        
    }

    private void Awake() {
        _instance = this;
    }

    public void carrotSeed(){
        data = carrotData;
        //carrotButton.interactable = true;
        //cabbageButton.interactable = false;

    }

    public void cabbageSeed(){
        data = cabbageData;
       // carrotButton.interactable = false;
        //cabbageButton.interactable = true;

    }

    public void SeedTypeChosen(){

       
    }
  
}
