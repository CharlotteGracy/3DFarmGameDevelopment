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
    public CropData watermelonData;
    public CropData pumpkinData;
    public CropData sunflowerData;
    public CropData wheatData;

    [Header("Sprite")]
    public Sprite normalButton;
    public Sprite selectedButton;

    [Header("Button")]
    public Button carrotButton;
    public Button cabbageButton;
    public Button watermelonButton;
    public Button pumpkinButton;
    public Button sunflowerButton;
    public Button wheatButton;




    private void Start() {
        
    }

    private void Awake() {
        _instance = this;
    }

    public void carrotSeed(){
        data = carrotData;
        //선택된 버튼을 색으로 보여줌
        carrotButton.image.sprite = selectedButton;
        cabbageButton.image.sprite = normalButton;
        watermelonButton.image.sprite = normalButton;
        pumpkinButton.image.sprite = normalButton;
        sunflowerButton.image.sprite = normalButton;
        wheatButton.image.sprite = normalButton;

    }

    public void cabbageSeed(){
        data = cabbageData;
      
        carrotButton.image.sprite = normalButton;
        cabbageButton.image.sprite = selectedButton;
        watermelonButton.image.sprite = normalButton;
        pumpkinButton.image.sprite = normalButton;
        sunflowerButton.image.sprite = normalButton;
        wheatButton.image.sprite = normalButton;

    }

    public void watermelonSeed(){
       data = watermelonData;
        carrotButton.image.sprite = normalButton;
        cabbageButton.image.sprite = normalButton;
        watermelonButton.image.sprite = selectedButton;
        pumpkinButton.image.sprite = normalButton;
        sunflowerButton.image.sprite = normalButton;
        wheatButton.image.sprite = normalButton;
    }

    public void pumpkinSeed(){
        data = pumpkinData;
        carrotButton.image.sprite = normalButton;
        cabbageButton.image.sprite = normalButton;
        watermelonButton.image.sprite = normalButton;
        pumpkinButton.image.sprite = selectedButton;
        sunflowerButton.image.sprite = normalButton;
        wheatButton.image.sprite = normalButton;
    }

    public void sunflowerSeed(){
        data = sunflowerData;
        carrotButton.image.sprite = normalButton;
        cabbageButton.image.sprite = normalButton;
        watermelonButton.image.sprite = normalButton;
        pumpkinButton.image.sprite = normalButton;
        sunflowerButton.image.sprite = selectedButton;
        wheatButton.image.sprite = normalButton;
    }

    public void wheatSeed(){
        data = wheatData;
        carrotButton.image.sprite = normalButton;
        cabbageButton.image.sprite = normalButton;
        watermelonButton.image.sprite = normalButton;
        pumpkinButton.image.sprite = normalButton;
        sunflowerButton.image.sprite = normalButton;
        wheatButton.image.sprite = selectedButton;
    }


    public void SeedTypeChosen(){

       
    }
  
}
