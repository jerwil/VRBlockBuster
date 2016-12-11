using UnityEngine;
using System.Collections;

public class CubeFall : MonoBehaviour {

    public GameObject[] ScoredBlocks;

    // Use this for initialization
    void Start () {

        ScoredBlocks = GameObject.FindGameObjectsWithTag("ScoreBlock");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
