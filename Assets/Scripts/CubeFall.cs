using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CubeFall : MonoBehaviour {

    public GameObject[] ScoredBlocks;
    public Rigidbody rb;
    public Text VRScoreTxt;

    private int count; // Current Score

    // Use this for initialization
    void Start () {

        ScoredBlocks = GameObject.FindGameObjectsWithTag("ScoreBlock");
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        VRScoreTxt.text = "Score: " + count;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreBlock"))
        {
            other.gameObject.SetActive(false);
            count += 1;            
            Debug.Log(count);
        }
    }

}
