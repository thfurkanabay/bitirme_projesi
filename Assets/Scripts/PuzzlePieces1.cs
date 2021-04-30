using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieces1 : MonoBehaviour
{
    //Touch inputs pcde, OnMouse mobilde çalışmaıdğı için ikisinin scriptini de tutuyorum.

    public float tolerance;                                                                      //Hedefe ne kadar yaklaşması gerektiğini belirten tolerans değeri
    public Transform piecePlace;                                                                 //Hedef objesi(tile)

    public bool atTarget = false;

    private float xPosition, yPosition;
    private Vector2 mousePosition;
    private Vector2 clickPosition;
    private GameObject gameController;
    private bool gameFinished;

    //Collider2D col;

    void Start()
    {
        gameController = GameObject.Find("GameController");                                       //Public belirtmek istemediğim için isimle buldurttum.
    }

    private void Update()
    {
        gameFinished = gameController.GetComponent<Puzzle4PieceController>().gameFinished;

        if (atTarget)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;                            //Eğer hedefteyse diğer puzzle parçalarının altında kalması için order in layer komutu
        }
    }

    //Puzzle hareket fonksiyonları
    //İlk tıklamada timer başlatılıyor.
    private void OnMouseDown()
    {
        if (!atTarget && !gameFinished)
        {
            xPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            yPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }     
    }

    private void OnMouseDrag()
    {
        if (!atTarget && !gameFinished)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - xPosition, mousePosition.y - yPosition);
        }
    }

    //Hedefte ise konumu kilitleniyor.
    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - piecePlace.position.x) <= tolerance && Mathf.Abs(transform.position.y - piecePlace.position.y) <= tolerance && !atTarget)
        {
            transform.position = piecePlace.position;
            atTarget = true;
            gameController.GetComponent<Puzzle4PieceController>().PieceFit();
        }
    }
}
