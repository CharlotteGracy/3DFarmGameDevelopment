using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneButtonChange : MonoBehaviour
{
    public GameObject KitchenUI;
    public GameObject ToolUI;
    public Button kitchenCloseButton, toolCloseButton;


    public void GoToBarn(){
        Debug.Log("Barn!");
        SceneManager.LoadScene("BarnScene");

    }

    public void KitchenUIOn(){
        Debug.Log("Kitchen!");
        KitchenUI.SetActive(true);
        kitchenCloseButton.onClick.AddListener(()=>{KitchenUI.SetActive(false);});

    }

    public void ToolUIOn(){
        ToolUI.SetActive(true);
        toolCloseButton.onClick.AddListener(()=>{ToolUI.SetActive(false);});
    }
    
}
