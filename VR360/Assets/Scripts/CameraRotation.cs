using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject camHolder;
    private Quaternion rot;
    private void Start()
    {
        camHolder = new GameObject("Camera Holder");
        camHolder.transform.position = transform.position;
        transform.SetParent(camHolder.transform);

        gyroEnabled = GyroEnabeler();
    }

    private bool GyroEnabeler()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            camHolder.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
