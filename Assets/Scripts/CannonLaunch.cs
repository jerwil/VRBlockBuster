using UnityEngine;
using System.Collections;

public class CannonLaunch : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {

        rb.AddForce(0,0,thrust);

    }
}
