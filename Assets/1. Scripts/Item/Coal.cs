using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour
{
    //클릭당했을 때 Storage에 Coal이 들어가도록 해야함.

    private void Update() {
        
    }


    public void CoalCollected(){
    Debug.Log("Coal 수집!");

    }

    private void OnMouseDown() {
        //Debug.Log(gameObject.name);
        gameObject.SetActive(false);

        Debug.Log("Coal Clicked!");
        
    }


}
