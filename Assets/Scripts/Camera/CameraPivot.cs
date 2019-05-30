using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class CameraPivot: MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;

    private float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        mouseX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, mouseX, 0f);
    }
}
