This project is a chess game made with unity and C#.

Logs:

09/07/22 : (time spent: ~4h)
Made the board as well as a tile/piece highlight system to show the player which tile of the board he is currently on


13/07/22 : 
Added highlight effect. 
Started making piece specific classes and their prefabs.
Started the piece selector system.


19/07/22 :
Finished (kinda...) the selection system ->
    When clicking on a tile if there is a piece in it, it is selected. 
    If clicking on the same tile the selection is cancel.
    If clicking on another tile the selection cancel and it checks if there is a piece inside this new tile.

To improve this system I need to add a condition to consider the current player's pieces as the only selectable pieces, as well as implementing the pieces movements so that I can actually make them move around the board (and then be able to eat another piece by moving on the same tile). 
For the movements, I should first complete the buildAllowedMoves function by giving the ability to move everywhere on the board. That way i can check if the piece can properly move around and add the ability to eat the enemy pieces.




Left to do: (Basic)
Make different pieces and their moves
Make a turn based system and eventually a timer to go with it as well as a turn counter
Allow the player to pick a piece and move it around
Make a menu
Add sounds

