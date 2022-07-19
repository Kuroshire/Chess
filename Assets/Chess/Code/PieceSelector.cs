using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is a singleton that will handle the currently selected piece by the player.
//The selected piece cannot be moved if it isn't owned by the current player.
//The player cannot select a piece if it isn't their turn yet.
public class PieceSelector : MonoBehaviour
{

    //reference to the player

    public static PieceSelector INSTANCE;
    Piece selection;

    public void initSingleton(){
        if(INSTANCE == null){
            INSTANCE = this;
        }
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        initSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        //Input.mousePosition;
    }

    public static void setSelectedPiece(Piece selected){
        if(INSTANCE.selection){
            INSTANCE.selection.undoSelectPiece();
        }
        //check if selectable before.
        INSTANCE.selection = selected;
    }

    public static Piece getSelectedPiece(){
        return INSTANCE.selection;
    }

    public static void cancelSelection(){
        INSTANCE.selection = null;
    }
}
