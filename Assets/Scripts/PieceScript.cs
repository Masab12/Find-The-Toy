using UnityEngine;

public class PieceScript : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public string pieceTag = "Piece";

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position and check if it hits this gameobject
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Piece")))
            {
                if (hit.collider.gameObject == gameObject && hit.collider.gameObject.tag == pieceTag)
                {
                    // Piece found, update PuzzleManager
                    puzzleManager.DecrementPiecesNeeded();
                    puzzleManager.IncrementPiecesFound();
                    Destroy(gameObject);
                    Debug.Log("Piece Found");
                }
            }
        }
    }
}