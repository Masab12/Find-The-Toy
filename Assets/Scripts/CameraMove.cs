using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 5.0f;

    private float mouseX = 0.0f;
    private float mouseY = 0.0f;

    void Update()
    {
       
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

      
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, 0, verticalInput * moveSpeed * Time.deltaTime);

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.eulerAngles = new Vector3(0, mouseX, 0);

        
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -90.0f, 90.0f);
        Camera.main.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);
    }
}


