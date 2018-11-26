using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {
    public float speed;
    void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward*speed;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
