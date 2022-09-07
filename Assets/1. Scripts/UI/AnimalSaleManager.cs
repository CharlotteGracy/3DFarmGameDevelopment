using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSaleManager : Singleton<AnimalSaleManager>
{

    [Header("Animal Prefabs")]
    public GameObject hen;
    public GameObject pig;
    public GameObject cow;

    [Header("Animal Nums")]
    public int henNum;
    public int pigNum;
    public int cowNum;

    public Message b_messageText;




    public GameObject barnCollider;
    private BoxCollider area;
    private int animalCost;


    private void Awake() {
        _instance = this;
    }
    
    private void Start() {
        area = barnCollider.GetComponent<BoxCollider>();
    }

    public Vector3 GetRandomPos(){
        Vector3 basePosition = barnCollider.transform.position;
        Vector3 size = area.size;

        float newX = basePosition.x + Random.Range(-size.x/2f + 0.2f, size.x/2f - 0.2f);
        float newY = -50.24841f;
        float newZ = basePosition.z + Random.Range(-size.z/2f + 0.2f, size.z/2f - 0.2f);
        Vector3 spawnPos = new Vector3(newX, newY, newZ);
        return spawnPos;
    }

   
    public void BuyHen(){
        animalCost = 100;

        if(FinanceManager.Instance.curMoney>=animalCost){
            FinanceManager.Instance.curMoney = FinanceManager.Instance.curMoney - animalCost;
            GameObject newOne = Instantiate(hen);
            newOne.transform.position = GetRandomPos();
            henNum += 1;
        }
        else{
            b_messageText.NotEnoughMoney();
        }
    }

    public void BuyPig(){
        animalCost = 500;

        if(FinanceManager.Instance.curMoney>=animalCost){
            FinanceManager.Instance.curMoney = FinanceManager.Instance.curMoney - animalCost;
            GameObject newOne = Instantiate(pig);
            newOne.transform.position = GetRandomPos();
            pigNum += 1;
        }
        else{
            b_messageText.NotEnoughMoney();

        }
    }

    public void BuyCow(){
        animalCost = 1000;

        if(FinanceManager.Instance.curMoney>=animalCost){
            FinanceManager.Instance.curMoney = FinanceManager.Instance.curMoney - animalCost;
            GameObject newOne = Instantiate(cow);
            newOne.transform.position = GetRandomPos();
            cowNum += 1;
        }
        else{
            b_messageText.NotEnoughMoney();

        }
    }
}
