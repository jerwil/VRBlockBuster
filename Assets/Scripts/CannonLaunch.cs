using UnityEngine;
using System.Collections;

public class CannonLaunch : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;
    private Transform vrHead;
    public bool inMotion = false;
    public bool projectileReset = true;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        vrHead = Camera.main.transform;

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 forward = vrHead.TransformDirection(Vector3.forward); // Thanks to https://www.youtube.com/watch?v=JmgOeQ3Gric for the help on this one

        if (!inMotion) { transform.position = vrHead.position + forward * 2; }

        // if (GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.Triggered)
        if (Input.GetButtonDown("Fire1") && !inMotion)
        {            
            rb.isKinematic = false;
            rb.AddForce(forward * 100, ForceMode.Impulse);
            Debug.Log("Trigger pressed!");
            inMotion = true;
            projectileReset = false;
        }

        if (transform.position.y < 0) {

            transform.position = new Vector3(0, 10, -9);
            rb.isKinematic = true;
            inMotion = false;
            projectileReset = true;

        }

    }
}
