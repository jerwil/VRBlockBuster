﻿using UnityEngine;
using System.Collections;

public class NonVRCamera : MonoBehaviour {

    CursorLockMode wantedMode;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetButtonDown("Fire2"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else { Cursor.lockState = CursorLockMode.Locked; }
        }
    }
}
