using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Kicker : MonoBehaviour {
    public GameObject IDW;
    // Use this for initialization
    void Start () {

        IDW.GetComponent<Rigidbody>().AddForce(1500, 1000, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
