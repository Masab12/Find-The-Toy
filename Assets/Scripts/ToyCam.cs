using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCam : MonoBehaviour
{
    public Transform target; // The target object to move towards
    public float moveSpeed = 1f; // The speed to move towards the target
    public float rotateSpeed = 5f; // The speed to rotate towards the target

    private bool isMoving = false; // Flag to check if the camera is currently moving towards the target

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is clicked
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) // Check if the raycast hits a collider
            {
                if (hit.collider.gameObject == this.gameObject) // Check if the collider is this toy object
                {
                    target = this.transform; // Set the target to be this toy object
                    isMoving = true; // Set the moving flag to true
                }
            }
        }

        if (isMoving) // If the moving flag is true, move the camera towards the target
        {
            Vector3 direction = target.position - Camera.main.transform.position;
            // Get the direction to move towards
            Quaternion rotation = Quaternion.LookRotation(direction); // Get the rotation to face towards the target
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, rotation, Time.deltaTime * rotateSpeed); // Rotate the camera towards the target
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target.position, Time.deltaTime * moveSpeed); // Move the camera towards the target

            if (Vector3.Distance(Camera.main.transform.position, target.position) < 0.5f) // Check if the camera has reached the target
            {
                isMoving = false; // Set the moving flag to false
            }
        }
    }
}