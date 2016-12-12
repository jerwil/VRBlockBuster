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

        if (inMotion) { transform.position = projectile.transform.position + offset; }
        else if (projectileReset) {
            offset = transform.position - projectile.transform.position;
            transform.position = new Vector3(0, 10, -15);
        }
    }
}
