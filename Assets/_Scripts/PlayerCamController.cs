using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamController : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;

    [SerializeField] Transform orientation;

    float xRotation;
    float yRotation;

    Vector2 lookInput;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
        lookInput.x = lookInput.x * Time.deltaTime * sensX; 
        lookInput.y = lookInput.y * Time.deltaTime * sensY; 
        
    } 

    // Update is called once per frame
    void Update()
    {
        yRotation += lookInput.x;
        xRotation -= lookInput.y;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
