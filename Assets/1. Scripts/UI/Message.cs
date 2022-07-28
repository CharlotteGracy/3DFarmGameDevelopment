using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message : MonoBehaviour
{
    public TMP_Text notice;
    
    TextMeshProUGUI mText;

    private void Awake() {
        mText = GetComponent<TextMeshProUGUI>();
    }

    public void NoSeedSelected(){
        mText.enabled = true;
        notice.text = "No Seeds Selected!";
        StartCoroutine(MessageTwinkle());
    }

    public void NoShovelUsed(){
        mText.enabled = true;
        notice.text = "Use the shovel first!";
        StartCoroutine(MessageTwinkle());

    }

    public void AlreadyPlanted(){
        mText.enabled = true;
        notice.text = "Already Planted!";
        StartCoroutine(MessageTwinkle());

    }

    public void CropHarvested(){
        mText.enabled = true;
        notice.text = "Harvested!";
        StartCoroutine(MessagePop());

    }

    public void FullStorage(){
        mText.enabled = true;
        notice.text = "The Storage is Full!";
        StartCoroutine(MessageTwinkle());

    }


    IEnumerator MessageTwinkle(){
        yield return new WaitForSecondsRealtime(0.3f);
        mText.enabled = false;
        yield return new WaitForSecondsRealtime(0.3f);
        mText.enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
        mText.enabled = false;

    }

    IEnumerator MessagePop(){
        yield return new WaitForSecondsRealtime(0.8f);
        mText.enabled = false;
    }














}
