using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Gyroscope gyro;

    // Update is called once per frame
    void Update()
    {
        ModifyGyro();
    }

    public void ModifyGyro()
    {
        transform.rotation = GyroToUnity(gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
