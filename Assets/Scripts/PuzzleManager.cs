using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public int piecesNeeded;
    public int piecesFound;
    public Text piecesNeededText;
    public Text piecesFoundText;

    void Start()
    {
        // Initialize piecesNeeded based on the number of Piece gameobjects in the scene
        piecesNeeded = GameObject.FindGameObjectsWithTag("Piece").Length;
        piecesNeededText.text = piecesNeeded.ToString();
    }

    public void DecrementPiecesNeeded()
    {
        piecesNeeded--;
        piecesNeededText.text = piecesNeeded.ToString();
        CheckPuzzleCompleted();
    }

    public void IncrementPiecesFound()
    {
        piecesFound++;
        piecesFoundText.text = piecesFound.ToString();
        CheckPuzzleCompleted();
    }

    void CheckPuzzleCompleted()
    {
        if (piecesNeeded == 0)
        {
            Debug.Log("Puzzle completed!");
           
        }
    }
}