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
        GameObject projectile = GameObject.Find("CannonBall");
        int ammo = projectile.GetComponent<CannonLaunch>().ammo;
        GameObject levelsystem = GameObject.Find("LevelSwitchSystem");
        int level = levelsystem.GetComponent<LevelChange>().level;
        VRScoreTxt.text = "Score: " + count +"/200" + " Ammo: " + ammo + " Level: " + level;
        if (count >= 200) {
            projectile.GetComponent<CannonLaunch>().projectileMode = 1;
            VRScoreTxt.text += "      Missile Mode!";
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreBlock"))
        {
            Destroy(other.gameObject);
            count += 1;            
            Debug.Log(count);
        }
    }

}
