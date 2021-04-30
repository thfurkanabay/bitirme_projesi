using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4PieceController : MonoBehaviour
{
    public bool gameFinished = false;
    private int pieceNumber = 0;

    public void PieceFit()
    {
        pieceNumber += 1;
        if(pieceNumber == 4)
        {
            gameFinished = true;
        }
    }
}
