using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class CameraPosition : MonoBehaviour
{
    //track player position
    [SerializeField]
    Transform playerTransform;
    Vector3 originalPosition;
    
    void Start()
    {
        originalPosition = transform.position;
    }
    
    void Update()
    {
        //track player position
        transform.position = originalPosition + playerTransform.position;
    }
}
