using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = transform.position + new Vector3(0, 0, -10);
        if (cam)
            cam.transform.position = Vector3.Lerp(cam.transform.position, destination, 0.9f);
    }
}
