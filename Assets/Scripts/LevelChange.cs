using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

    private GameObject[] OldBlocks;
    const int numberOfLevels = 5;
    public GameObject[] Levels = new GameObject[numberOfLevels];
    public int level = 3;
    private int lastlevel = -1;

	// Use this for initialization
	void Start () {
        //Instantiate(Levels[0]);
    }
	
	// Update is called once per frame
	void Update () {
	    if (level != lastlevel)
        {
            Debug.Log("The last level was: " + lastlevel + " and the current level is: " + level);
            if (level >= 1)
            {
                OldBlocks = GameObject.FindGameObjectsWithTag("ScoreBlock");
                for (int i = 0; i < OldBlocks.Length; i++)
                {
                    Destroy(OldBlocks[i]);
                }
            }
            if (level >= numberOfLevels)
            {
                level = 0;
            }
            GameObject Newlevel = Instantiate(Levels[level]);
            Newlevel.SetActive(true);
            lastlevel = level;            
        }
	}
}
