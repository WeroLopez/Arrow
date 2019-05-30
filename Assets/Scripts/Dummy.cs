using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour {
    
    void Start()
    {
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Arrow") {
            Debug.Log("Le diste al dummy");
        }
    }
    
}
