using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightEffect : MonoBehaviour
{

    [SerializeField] List<SpriteRenderer> highlight;

    public void changeColor(Color newColor){
        foreach(SpriteRenderer spr in highlight){
            spr.color = newColor;
        }
    }

    public void turnOn(){
        gameObject.SetActive(true);
    }

    public void turnOff(){
        gameObject.SetActive(false);
    }
}
