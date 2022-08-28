using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSales : MonoBehaviour
{

    public GameObject hen;
    public GameObject pig;
    public GameObject cow;

    public GameObject barnCollider;

    private BoxCollider area;
    
    private void Start() {
        area = barnCollider.GetComponent<BoxCollider>();
    }

    private Vector3 GetRandomPos(){
        Vector3 basePosition = barnCollider.transform.position;
        Vector3 size = area.size;

        float newX = basePosition.x + Random.Range(-size.x/2f + 0.2f, size.x/2f - 0.2f);
        float newY = -50.24841f;
        float newZ = basePosition.z + Random.Range(-size.z/2f + 0.2f, size.z/2f - 0.2f);
        Vector3 spawnPos = new Vector3(newX, newY, newZ);
        return spawnPos;
    }

   
    public void BuyHen(){
        GameObject newOne = Instantiate(hen);
        newOne.transform.position = GetRandomPos();
      //  hen.transform.position = GetRandomPos();
        Debug.Log(barnCollider.transform.position);
        Debug.Log(area.size.x);
        Debug.Log(area.size.z);
    }

    public void BuyPig(){
        GameObject newOne = Instantiate(pig);
        newOne.transform.position = GetRandomPos();

    }

    public void BuyCow(){
        GameObject newOne = Instantiate(cow);
        newOne.transform.position = GetRandomPos();

    }
}
