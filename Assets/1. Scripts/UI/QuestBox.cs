using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBox : MonoBehaviour
{
    public GameObject check;

    public void QuestDone(){
        check.SetActive(true);
    }
}
