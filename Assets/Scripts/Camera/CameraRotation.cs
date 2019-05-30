using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
    
    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        mouseX = 0;
        mouseY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -40, 70);
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }
}
