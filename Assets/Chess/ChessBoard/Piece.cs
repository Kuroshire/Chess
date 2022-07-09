using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] SpriteRenderer highligthEffect;

    // Start is called before the first frame update
    void Start()
    {
        stopHighlightPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highlightPiece(){
        highligthEffect.color = Color.green; 
    }

    public void stopHighlightPiece(){
        highligthEffect.color = new Color(0, 255, 0, 0);
    }
}
