using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 685);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
