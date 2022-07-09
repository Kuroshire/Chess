using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Color tileColor;
    Piece currentPiece;

    private void Start() {
        tileColor = this.gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void setCurrentPiece(Piece p){
        currentPiece = p;
    }







    private void OnMouseEnter() {
        highlightTile();
    }

    private void OnMouseExit() {
        stopHighlightTile();
    }

    void highlightTile(){
        if(currentPiece){
            currentPiece.highlightPiece();
            return;
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    void stopHighlightTile(){
        if(currentPiece){
            currentPiece.stopHighlightPiece();
            return;
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = tileColor;
    }

    public void setPiece(Piece p){
        currentPiece = p;
        currentPiece.transform.position = transform.position;
    }
}
