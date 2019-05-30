using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.ObjectPooler;

#pragma warning disable 0649

public class Arrows : MonoBehaviour {

	[SerializeField]
	protected string poolTag;

	[SerializeField]
	float force;
	Rigidbody rb;
	ObjectPooler objectPooler;

    bool firstEnable;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        firstEnable = true;
    }

    void Start() {
		objectPooler = ObjectPooler.Instance;
	}

    void OnTriggerEnter(Collider other){
		if (other.tag != "Player" && other.tag != "NPC" && other.tag != "Damage" && other.tag != "Guard" && other.tag != "Arrows" && other.tag != "HealthPickup" && other.tag != "ManaPickup" && other.tag != "Music") {
            if(other.tag != "Floor")
            rb.velocity = Vector3.zero;
			rb.useGravity = false;
			objectPooler.ReturnObjectToPool("Arrow", gameObject);
		}
	}

    private void OnEnable() {
        if(!firstEnable) {
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
        else {
            firstEnable = false;
        }
    }

}
