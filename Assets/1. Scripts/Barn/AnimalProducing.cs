using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalProducing : MonoBehaviour

{

    public GameObject egg;
    public GameObject ham;
    public GameObject milk;

    public enum AnimalType{HEN, PIG, COW,};
    public AnimalType animalType;

    // Start is called before the first frame update

    private void Update() {
        Move();
        Produce();
    }


    public void Move(){
        Vector3 targetPosition = AnimalSaleManager.Instance.GetRandomPos();
        Vector3 curPosition = this.gameObject.transform.position;

    }



    //동물 종류에 알맞게 생산품 생성
    public void Produce(){
        switch(animalType){
            case AnimalType.HEN:
            StartCoroutine(HenProduce());
            break;
            case AnimalType.PIG:
            StartCoroutine(PigProduce());
            break;
            case AnimalType.COW:
            StartCoroutine(CowProduce());
            break;            
        }
        
    }

    IEnumerator HenProduce(){
        yield return new WaitForSeconds(4f);


    }

    IEnumerator PigProduce(){
        yield return new WaitForSeconds(5f);

    }
    IEnumerator CowProduce(){
        yield return new WaitForSeconds(8f);

    }
         
}
