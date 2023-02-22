using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPuzzle : MonoBehaviour
{
    public GameObject realToy;
    public GameObject fakeToy;
    public int numTries = 3;

    private int currentTries = 0;
    private bool gameWon = false;

    private void Start()
    {
        // Randomly choose which toy is the real one
        if (Random.Range(0, 2) == 0)
        {
            realToy.SetActive(true);
            fakeToy.SetActive(false);
        }
        else
        {
            realToy.SetActive(false);
            fakeToy.SetActive(true);
        }
    }

    public void CheckAnswer(bool isRealToy)
    {
        if (gameWon)
        {
            return; // If the game is already won, do nothing
        }

        currentTries++;

        if (isRealToy)
        {
            // The player correctly identified the real toy
            Debug.Log("You win!");
            gameWon = true;
        }
        else
        {
            // The player chose the fake toy
            Debug.Log("Try again");

            if (currentTries >= numTries)
            {
                // The player has used up all their tries and lost the game
                Debug.Log("You lose");
                gameWon = true;
            }
        }
    }
}