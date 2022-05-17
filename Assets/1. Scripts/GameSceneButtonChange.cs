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
    private bool ToolUISwitchOn = false;


    public Button kitchenCloseButton, toolCloseButton, yesButton, noButton;


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

 
    
}
