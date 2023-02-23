using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 1f; // The speed at which the camera will zoom in
    public float maxZoom = 1f; // The maximum distance the camera can zoom in
    public string zoomTag = "Toy"; // The tag for the object to zoom in on

    private Camera mainCamera; // Reference to the main camera
    private Vector3 originalPosition; // The original position of the camera before zooming in
    private bool isZoomedIn = false; // Flag to check if the camera is currently zoomed in
    private RaycastHit hit; // Store the last hit information

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera component
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is clicked
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) // Check if the raycast hits a collider
            {
                if (hit.collider.gameObject.tag == zoomTag) // Check if the collider has the specified tag
                {
                    if (!isZoomedIn) // Check if the camera is not already zoomed in
                    {
                        originalPosition = mainCamera.transform.position; // Save the original position of the camera
                        isZoomedIn = true; // Set the zoomed in flag to true
                    }
                }
                else if (hit.collider.gameObject.tag == "Piece") // Check if the collider has the "Piece" tag
                {
                    // Do nothing if the "Piece" tag is clicked
                }
                else // If the clicked object is not the target or a piece, zoom out and reset flags
                {
                    mainCamera.transform.position = originalPosition; // Reset the camera to its original position
                    isZoomedIn = false; // Set the zoomed in flag to false
                }
            }
        }
        if (isZoomedIn) // If the zoomed in flag is true, zoom the camera towards the target
        {
            Vector3 direction = (mainCamera.transform.position - hit.collider.transform.position).normalized;
            float distance = Vector3.Distance(mainCamera.transform.position, hit.collider.transform.position);
            float zoomAmount = Mathf.Clamp(distance, 0, maxZoom);

            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, hit.collider.transform.position + (direction * zoomAmount), Time.deltaTime * zoomSpeed); // Move the camera towards the target

            if (isZoomedIn && Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag != zoomTag && hit.collider.gameObject.tag != "Piece") // Check if the left mouse button is clicked and not on the same object or piece
            {
                mainCamera.transform.position = originalPosition; // Reset the camera to its original position
                isZoomedIn = false; // Set the zoomed in flag to false
            }
        }
    }
}