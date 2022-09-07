using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class QuestBox : MonoBehaviour
{
    public GameObject check;
    public TMP_Text itemNumText;
    TextMeshProUGUI itemNum;
    public int boxNum;
    

    public int curNum;
    public int goalNum;

    //public ISubject subject;
    //public UnityEvent OnProductGet;

    //UnityEvent OnProductGet = new UnityEvent();

    private void Start() {
     // OnProductGet.AddListener(ProductNum);


      if(BarnCountManager.Instance != null){
      }
      QuestReset();


      
    }
    private void Awake() {
      itemNum = itemNumText.GetComponent<TextMeshProUGUI>();
    }

    public void OnProductGet(){
      ProductNum();
    }

    public void QuestDone(){
     
      if(goalNum != 0 && curNum == goalNum){
        check.SetActive(true);
        itemNumText.enabled = false;
      }
    }

    public void ProductNum(){

      if(boxNum == 1){
        curNum =  BarnCountManager.Instance.eggNum;
        goalNum = LevelManager.Instance.goalEgg;
      }
      if(boxNum == 2){
        curNum =  BarnCountManager.Instance.hamNum;
        goalNum = LevelManager.Instance.goalHam;
      }
      if(boxNum == 3){
        curNum =  BarnCountManager.Instance.milkNum;
        goalNum = LevelManager.Instance.goalMilk;
      }

      if(goalNum == 0){
        itemNumText.text = "-";
      }
      else{
        itemNumText.text = string.Format("{0}/{1}",curNum, goalNum);

      }

  



      QuestDone();
    }


    public void QuestReset(){
      check.SetActive(false);
      itemNumText.enabled = true;
    }
}
