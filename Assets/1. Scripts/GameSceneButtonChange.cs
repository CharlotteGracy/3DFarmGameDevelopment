using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameSceneButtonChange : Singleton<GameSceneButtonChange>
{



    [Header("UI")]
    public GameObject KitchenUI;
    public GameObject ToolUI;
    public GameObject ExitUI;
    public GameObject StoreUI;
    public GameObject SeedTypeUI;
    public GameObject StorageUI;

    [Header("Text")]
    public GameObject toolText;
    public GameObject closeText;

    [Header("Tools")]

    public GameObject shovel;
    public GameObject seed;
    public GameObject wateringCan;

    public bool ToolUISwitchOn = false;
    public bool ShovelSelectOn = false;
    public bool SeedSelectOn = false;
    public bool WateringCanSelectOn = false;
    public bool StorageUIOnOff = false;
    public Button shovelButton, seedButton, wateringCanButton;


    [Header("Buttons")]

    public Button kitchenCloseButton, storeCloseButton, toolCloseButton, yesButton, noButton;
    public Button storageButton;

   
    private void Awake() {
        _instance = this;
    }


    public void GoToBarn(){
        Debug.Log("Go to Barn!");
        

    }

    public void KitchenUIOn(){
        KitchenUI.SetActive(true);
        kitchenCloseButton.onClick.AddListener(()=>{KitchenUI.SetActive(false);});

    }

    public void ToolUIOn(){
        ToolUI.SetActive(true);
        toolText.SetActive(false);
        closeText.SetActive(true);
        ToolUISwitchOn = true;
    
    }


    public void ToolUIOff(){
        ToolUI.SetActive(false);
        closeText.SetActive(false);
        toolText.SetActive(true);
        ToolUISwitchOn = false;
        SeedTypeUI.SetActive(false);

    }


    public void ToolSwitch(){
        if(ToolUISwitchOn == false){
            ToolUIOn();
        }
        else if(ToolUISwitchOn == true){
            ToolUIOff();
        }
    }
    public void StoreUIOn(){
        StoreUI.SetActive(true);
        storeCloseButton.onClick.AddListener(()=>{StoreUI.SetActive(false);});
    }

    public void StorageUIOn(){
        if(StorageUIOnOff == false){
            StorageUI.SetActive(true);
            StorageUIOnOff = true;
        }
        else if(StorageUIOnOff == true){
            StorageUI.SetActive(false);
            StorageUIOnOff = false;
        }

    }


    public void ExitUIOn(){
        
        ExitUI.SetActive(true);
    
        noButton.onClick.AddListener(()=>{ ExitUI.SetActive(false);});
        yesButton.onClick.AddListener(Exit);
    }

    public void Exit(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }

    public void ShovelSwitch(){
        SeedTypeUI.SetActive(false);

        if(ShovelSelectOn == false){
            seed.SetActive(false);
            wateringCan.SetActive(false);
            shovel.SetActive(true);
            ShovelSelectOn = true;
            SeedSelectOn = false;            
            WateringCanSelectOn = false;            

        }
        else if(ShovelSelectOn == true){
            shovel.SetActive(false);
            ShovelSelectOn = false;
        }

    }

    public void SeedSwtich(){
        if(SeedSelectOn == false){
            shovel.SetActive(false);
            wateringCan.SetActive(false);
            seed.SetActive(true);
            ShovelSelectOn = false;
            SeedSelectOn = true;            
            WateringCanSelectOn = false;

            //SeedTypeUIOn         
            SeedTypeUI.SetActive(true); 
        }

        else if(SeedSelectOn == true){
            seed.SetActive(false);
            SeedSelectOn = false; 
            SeedTypeUI.SetActive(false);           
        }
    }

    public void WateringCanSwtich(){
        
        SeedTypeUI.SetActive(false);

        if(WateringCanSelectOn == false){

            shovel.SetActive(false);
            seed.SetActive(false);
            wateringCan.SetActive(true);
            ShovelSelectOn = false;
            SeedSelectOn = false;            
            WateringCanSelectOn = true;         
        }


        else if(WateringCanSelectOn == true){
            wateringCan.SetActive(false);
            WateringCanSelectOn = false;            
        }       
    }




 
    
}
