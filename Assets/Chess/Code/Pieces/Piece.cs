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



    // Start is called before the first frame update
    void Start()
    {
        stopHighlightPiece();
        highligth.changeColor(Color.blue);
    }

    public void highlightPiece(){
        highligth.turnOn();
    }

    public void stopHighlightPiece(){
        highligth.turnOff();
    }

    public List<Tile> getAllowedMoves(){
        return allowedMoves;
    }

    public virtual void buildAllowedMoves(){

    }

    public void emptyAllowedMoves(){
        allowedMoves.Clear();
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
