using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour
{

    private ItemData data;
    public CoalData coalData;
    //클릭당했을 때 Storage에 Coal이 들어가도록 해야함.

    private void Update() {
        
    }


    public void CoalCollected(){
    Debug.Log("Coal 수집!");
    }

    private void OnMouseDown() {
        gameObject.SetActive(false);
        Debug.Log("Coal Clicked!");

        //Storage에 아이템 들어가도록
        data = coalData;
        if(StorageManager.Instance.AddNum(data) == false){
        }
        else{
          
        }




        

        
    }


}
