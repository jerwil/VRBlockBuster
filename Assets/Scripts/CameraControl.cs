using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject projectile;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - projectile.transform.position;
}
	
	// Update is called once per frame
	void Update () {

        GameObject projectile = GameObject.Find("CannonBall");
        bool inMotion = projectile.GetComponent<CannonLaunch>().inMotion;
        bool projectileReset = projectile.GetComponent<CannonLaunch>().projectileReset;
        int projectileMode = projectile.GetComponent<CannonLaunch>().projectileMode;

        if (inMotion && transform.position.z < - 10 && projectileMode != 1) { transform.position = projectile.transform.position + offset; }
        else if (projectileReset) {
            offset = transform.position - projectile.transform.position;
            transform.position = new Vector3(0, 10, -15);
        }
    }
}
