using UnityEngine;
using System.Collections;

public class CannonLaunch : MonoBehaviour {

    private GameObject[] ScoredBlocks;
    public float thrust;
    public Rigidbody rb;
    private Transform vrHead;
    public bool inMotion = false;
    public bool projectileReset = true;
    public int ammo = 3;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        vrHead = Camera.main.transform;

    }
	
	// Update is called once per frame
	void Update () {

        ScoredBlocks = GameObject.FindGameObjectsWithTag("ScoreBlock");
        Vector3 forward = vrHead.TransformDirection(Vector3.forward); // Thanks to https://www.youtube.com/watch?v=JmgOeQ3Gric for the help on this one

        if (ScoredBlocks.Length <= 0)
        {
            GameObject levelsystem = GameObject.Find("LevelSwitchSystem");
            levelsystem.GetComponent<LevelChange>().level += 1;
            ammo = 3;
        }

        if (!inMotion) { transform.position = vrHead.position + forward * 4; }

        // if (GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.Triggered)
        if (Input.GetButtonDown("Fire1") && !inMotion)
        {            
            rb.isKinematic = false;
            rb.AddForce(forward * 100, ForceMode.Impulse);
            Debug.Log("Trigger pressed!");
            inMotion = true;
            ammo -= 1;
            projectileReset = false;
        }

        else if (transform.position.y < 0 || (Input.GetButtonDown("Fire1") && inMotion)) {

            transform.position = new Vector3(0, 10, -20);
            rb.isKinematic = true;
            inMotion = false;
            projectileReset = true;
            if (ammo <= 0) 
            {
                GameObject levelsystem = GameObject.Find("LevelSwitchSystem");
                levelsystem.GetComponent<LevelChange>().level += 1;
                ammo = 3;
            }

        }

    }
}
