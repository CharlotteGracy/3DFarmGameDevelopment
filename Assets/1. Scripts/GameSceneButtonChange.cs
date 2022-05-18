using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneButtonChange : MonoBehaviour
{
    public GameObject KitchenUI;
    public GameObject ToolUI;
    public GameObject ExitUI;
    public GameObject toolText;
    public GameObject closeText;
    public GameObject shovel;
    public GameObject seed;
    public GameObject wateringCan;

    private bool ToolUISwitchOn = false;
    private bool ShovelSelectOn = false;
    private bool SeedSelectOn = false;
    private bool WateringCanSelectOn = false;


    public Button kitchenCloseButton, toolCloseButton, yesButton, noButton;
    public Button shovelButton, seedButton, wateringCanButton;


    public void GoToBarn(){
        SceneManager.LoadScene("BarnScene");
        

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

    }


    public void ToolSwitch(){
        if(ToolUISwitchOn == false){
            ToolUIOn();
        }
        else if(ToolUISwitchOn == true){
            ToolUIOff();
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
        }

        else if(SeedSelectOn == true){
            seed.SetActive(false);
            SeedSelectOn = false;            
        }
    }

    public void WateringCanSwtich(){
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
