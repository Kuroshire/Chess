using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{

    TGrid<Tile> board = new TGrid<Tile>(8, 8);

    [SerializeField] GameObject whiteTile;
    [SerializeField] GameObject blackTile;

    [SerializeField] GameObject piece;

    [SerializeField] Transform piecesParent;


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

    public void createBoard(){
        
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

                    newTile.transform.parent = transform;
                    board.setTile(i, j, newTile);
                } catch(NullReferenceException e) {
                    print(e.Message);
                }
            }
        }

        //print(board);
    }

    public void createPieces(){
        try{
            //instantiate Kings

            //instantiate Queens

            //instantiate Bishops

            //instantiate Knights

            //instantiate Rooks

            //instantiate Pawns
            for(int i = 0; i < 8; i++){          
                //Black      
                instantiatePiece(i, 1, piece);
                //White
                instantiatePiece(i, 6, piece);
            }
        } 
        catch(NullReferenceException e) {
            print(e.Data);
        }
    }

    //Instantiate properly a new piece based on a prefab given. This allows use to instantiate different type of piece.
    void instantiatePiece(int i, int j, GameObject prefab){
        
        if(prefab.GetComponent<Piece>() == null){
            print("Error : trying to instantiate a prefab as a Piece");
            return;
        }

        GameObject newPiece = Instantiate(prefab, new Vector3(-1, 0, 0), Quaternion.identity);
        board.getTile(i, j).setPiece(newPiece.GetComponent<Piece>());
        newPiece.transform.parent = piecesParent;
    }

}
