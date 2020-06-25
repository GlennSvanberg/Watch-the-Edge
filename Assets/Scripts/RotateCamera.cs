using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private string horizontalString = "Horizontal";

    [SerializeField] float rotationSpeed = 10.0f;
    [SerializeField] float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis(horizontalString);
    }
    void LateUpdate()
    {
        
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
