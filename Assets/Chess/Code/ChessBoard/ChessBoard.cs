using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{

    TGrid<Tile> board = new TGrid<Tile>(8, 8);
    List<Piece> whitePieces = new List<Piece>();
    List<Piece> blackPieces = new List<Piece>();



    [SerializeField] GameObject whiteTile;
    [SerializeField] GameObject blackTile;

    [SerializeField] ObjectReferences references;

    [SerializeField] Transform piecesParent;
    [SerializeField] Transform tilesParent;



    // Start is called before the first frame update
    void Start()
    {
        createBoard();
        createPieces();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createBoard(){
        
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                try{
                    Tile newTile = null;
                    if((i + j) % 2 == 0){
                        newTile = Instantiate(whiteTile, new Vector3(i, -j, 0), Quaternion.identity).GetComponent<Tile>();
                    }
                    else {
                        newTile = Instantiate(blackTile, new Vector3(i, -j, 0), Quaternion.identity).GetComponent<Tile>();
                    }
                    //print("i = " + i + ", j = " + j + ", tile = " + newTile);

                    newTile.transform.parent = tilesParent;
                    newTile.setPosition((i, j));

                    board.setTile(i, j, newTile);

                } catch(NullReferenceException e) {
                    print(e.Message);
                }
            }
        }

        //print(board);
    }

    void createPieces(){
        try{
            //instantiate Kings
            instantiatePiece(4, 0, references.BlackKing);

            instantiatePiece(4, 7, references.WhiteKing);

            //instantiate Queens
            instantiatePiece(3, 0, references.BlackQueen);

            instantiatePiece(3, 7, references.WhiteQueen);

            //instantiate Bishops
            instantiatePiece(2, 0, references.BlackBishop);
            instantiatePiece(5, 0, references.BlackBishop);

            instantiatePiece(2, 7, references.WhiteBishop);
            instantiatePiece(5, 7, references.WhiteBishop);

            //instantiate Knights
            instantiatePiece(1, 0, references.BlackKnight);
            instantiatePiece(6, 0, references.BlackKnight);

            instantiatePiece(1, 7, references.WhiteKnight);
            instantiatePiece(6, 7, references.WhiteKnight);

            //instantiate Rooks
            instantiatePiece(0, 0, references.BlackRook);
            instantiatePiece(7, 0, references.BlackRook);

            instantiatePiece(0, 7, references.WhiteRook);
            instantiatePiece(7, 7, references.WhiteRook);

            //instantiate Pawns
            for(int i = 0; i < 8; i++){          
                //Black      
                instantiatePiece(i, 1, references.BlackPawn);
                //White
                instantiatePiece(i, 6, references.WhitePawn);
            }
        } 
        catch(NullReferenceException e) {
            print(e.Message);
        }
    }

    //Instantiate properly a new piece based on a prefab given. This allows use to instantiate different type of piece.
    void instantiatePiece(int i, int j, GameObject prefab){
        
        if(prefab.GetComponent<Piece>() == null){
            print("Error : Invalid prefab");
            return;
        }

        GameObject newPiece = Instantiate(prefab, new Vector3(-1, 0, 0), Quaternion.identity);
        board.getTile(i, j).setPiece(newPiece.GetComponent<Piece>());
        newPiece.transform.parent = piecesParent;
    }



}
