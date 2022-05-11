using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ButtonChange : MonoBehaviour
{

    public GameObject SettingsUI;
    public GameObject ExitUI;
    public Button noButton, yesButton, backButton;
  

    public void GameScenePlay(){
        SceneManager.LoadScene("GameScene");

    }
    public void SettingsUIOn(){
        SettingsUI.SetActive(true);
        backButton.onClick.AddListener(()=>{SettingsUI.SetActive(false);});

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
