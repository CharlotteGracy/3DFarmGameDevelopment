using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{

    public GameObject truckUI;

    private void OnMouseDown() {
        truckUI.SetActive(true);
    }

    public void truckUIClose(){
        truckUI.SetActive(false);
    }
}
