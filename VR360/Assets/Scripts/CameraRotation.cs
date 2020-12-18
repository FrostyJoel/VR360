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
        //Creates a cameraHolder and assings the camera to be a child of the holder
        camHolder = new GameObject("Camera Holder");
        camHolder.transform.position = transform.position;
        transform.SetParent(camHolder.transform);

        //Get's the gyro Input if available
        gyroEnabled = GyroEnabeler();
    }

    private bool GyroEnabeler()
    {
        //Check if the device supports a gyroscope
        if (SystemInfo.supportsGyroscope)
        {
            //Get's the gyro of the device
            gyro = Input.gyro;
            gyro.enabled = true;

            //sets a starting rotation
            camHolder.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            // if it has a gyroscpoe returns true
            return true;
        }
        //if no gyroscope is found return false
        return false;
    }

    void Update()
    {
        //Checks if the gyro is available and enabled
        if (gyroEnabled)
        {
            //if so rotate with the gyro
            transform.localRotation = gyro.attitude * rot;
        }
        else
        {
            //Debug if no gyro is connected
            if (Input.GetMouseButton(0))
            {
                Vector3 v = Vector3.zero;
                v.x = -Input.GetAxis("Mouse Y");
                v.y = Input.GetAxis("Mouse X");

                transform.Rotate(v.x * Vector3.right * Time.deltaTime * 90f);
                transform.Rotate(v.y * Vector3.up * Time.deltaTime * 90f);
            }
        }
    }
}
