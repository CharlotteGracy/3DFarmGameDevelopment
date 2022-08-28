using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnButtonChange : MonoBehaviour
{
    [Header("GameSceneUIs")]
    public GameObject toolButton;
    public GameObject storageButton;
    public GameObject questButton;
    public GameObject storeButton;
    public GameObject barnButton;
    public GameObject kitchenButton;


    public void BarnUI(){
        toolButton.SetActive(false);
        storageButton.SetActive(false);
        questButton.SetActive(false);
        storeButton.SetActive(false);
        barnButton.SetActive(false);
        kitchenButton.SetActive(false);

    }


}
