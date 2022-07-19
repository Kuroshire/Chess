using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Piece_Type{
    King,
    Queen,
    Bishop,
    Knight,
    Rook,
    Pawn
}

public enum Piece_Color{
    White, 
    Black
}

public class Piece : MonoBehaviour
{

    [SerializeField] HighlightEffect highligth;

    List<Tile> allowedMoves = new List<Tile>();

    (int, int) position;
    bool isAlive = true;

    Piece_Type type;
    Piece_Color color;

    bool isSelected = false;



    // Start is called before the first frame update
    void Start()
    {
        stopHighlightPiece();
        highligth.changeColor(Color.blue);
    }


    //region HIGHLIGHT ------------------------------------------------------------------------------------------------------------------------------

    public void highlightPiece(){
        highligth.turnOn();
    }

    //use when you want to turn off the highlight
    void stopHighlightPiece(){
        highligth.turnOff();
    }

    //use when you want to turn off the highlight if the piece isnt selected
    public void stopHighlightSelect(){
        if(isSelected)
            return;
        highligth.turnOff();
    }

    //region SELECTION ------------------------------------------------------------------------------------------------------------------------------

    public void selectPiece(){
        isSelected = true;
        PieceSelector.setSelectedPiece(this);
        showAllowedMoves();
        highlightPiece();
    }

    //called by cancelSelection
    public void undoSelectPiece(){
        isSelected = false;
        PieceSelector.cancelSelection();
        hideAllowedMoves();
        stopHighlightPiece();
    }

    public void switchIsSelected(){
        isSelected = !isSelected;

        if(isSelected){
            selectPiece();
        } else {
            undoSelectPiece();
        }
    }

    //region ALLOWED MOVES --------------------------------------------------------------------------------------------------------------------------

    public List<Tile> getAllowedMoves(){
        return allowedMoves;
    }

    public virtual void buildAllowedMoves(){

    }

    public void emptyAllowedMoves(){
        allowedMoves.Clear();
    }

    public void showAllowedMoves(){
        foreach(Tile tile in allowedMoves){
            tile.allowedMoveOn();
        }
    }

    public void hideAllowedMoves(){
        foreach(Tile tile in allowedMoves){
            tile.allowedMoveOff();
        }
    }

    //region GETTERS & SETTERS ----------------------------------------------------------------------------------------------------------------------

    public (Piece_Type, Piece_Color) getPieceInfos(){
        return (type, color);
    }

    public void setPosition((int, int) position){
        this.position = position;
    }

    public (int, int) getPosition(){
        return position;
    }

    
    //endregion -------------------------------------------------------------------------------------------------------------------------------------
}
