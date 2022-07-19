using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Color tileColor;
    SpriteRenderer spr;

    (int, int) position;
    
    Piece currentPiece;


    private void Start() {
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        tileColor = spr.color;
    }

    private void OnMouseEnter() {
        highlightTile();
    }

    private void OnMouseExit() {
        stopHighlightTile();

    }


    /*
    switchIsSelected ->
        isSelected ?
            selectPiece -> 
                setSelectPiece -> 
                    selection?
                        undoSelectPiece
                    :
            : undoSelectPiece -> 
                setSelectPiece -> 
                    selection?
                        cancelSelection
                    :
    */
    private void OnMouseDown() {

        //need to check which player turn it is then consider pieces of the enemy color as unselectable

        //tile isn't empty
        if(currentPiece) {
            //case : select a piece on the board (tile isn't empty)
            currentPiece.switchIsSelected();
        } 
        //tile is empty
        else {
            //a piece is selected
            if(PieceSelector.getSelectedPiece()){
                //case : move the selected piece to this tile (a piece is selected + tile is empty/tile store an enemy unit + authorized move)

                //case : cancel selection (a piece is selected + tile store an ally/not an authorized move)
                PieceSelector.getSelectedPiece().undoSelectPiece();
            }
        }
    }


    //region HIGHLIGHT ------------------------------------------------------------------------------------------------------------------------------

    //highlight the tile in a differenty color whenever the player move the mouse over it. If a piece is on the tile, the piece is highlighted instead.
    void highlightTile(){
        if(currentPiece){
            currentPiece.highlightPiece();
            return;
        }
        spr.color = Color.blue;
    }

    //undo the tile highlight
    void stopHighlightTile(){
        if(currentPiece){
            currentPiece.stopHighlightSelect();
            return;
        }
        spr.color = tileColor;
    }

    //highlight the tile if the chosen piece can move onto it.
    public void allowedMoveOn(){
        spr.color = Color.green;
    }

    //undo the tile highlight from allowedMoveOn. Called when the player confirm the move or when he decides
    public void allowedMoveOff(){
        spr.color = Color.green;
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
