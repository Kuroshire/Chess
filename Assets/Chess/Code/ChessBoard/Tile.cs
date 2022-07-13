using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Color tileColor;
    Piece currentPiece;

    (int, int) position;

    private void Start() {
        tileColor = this.gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void OnMouseEnter() {
        highlightTile();
    }

    private void OnMouseExit() {
        stopHighlightTile();
    }

    private void OnMouseDown() {
        if(currentPiece)
            PieceSelector.setSelectedPiece(currentPiece);
    }


    //region HIGHLIGHT ------------------------------------------------------------------------------------------------------------------------------

    //highlight the tile in a differenty color whenever the player move the mouse over it. If a piece is on the tile, the piece is highlighted instead.
    void highlightTile(){
        if(currentPiece){
            currentPiece.highlightPiece();
            return;
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    //undo the tile highlight
    void stopHighlightTile(){
        if(currentPiece){
            currentPiece.stopHighlightPiece();
            return;
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = tileColor;
    }

    //highlight the tile if the chosen piece can move onto it.
    public void moveHighlight(){

    }

    //undo the tile highlight from moveHighlight. Called when the player confirm the move or when he decides
    public void stopMoveHighlight(){

    }

    //endregion -------------------------------------------------------------------------------------------------------------------------------------

    public void setPosition( (int, int) position){
        this.position = position;
    }

    public (int, int) getPosition(){
        return position;
    }

    public void setPiece(Piece p){
        currentPiece = p;
        currentPiece.setPosition(position);
        currentPiece.transform.position = transform.position;
    }

    public Piece getPiece(){
        return currentPiece;
    }
}
