using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //References
    private Transform mainCamera;

    //Camera vars
    private float sensitivityX = 5f;        //Rotate
    private float sensitivityY = 2f;        //Rotate
    private float minimumY = -60f;          //Rotate
    private float maximumY = 10f;           //Rotate
    private float rotationX;                //X rotation of camera
    private float rotationY;                //Y rotation of camera
    private float cameraMoveSpeed = 0.5f;   //Move
    private float zoomSensitivity = 10f;    //Zoom
    private float maxZoomIn = -30;          //Zoom
    private float maxZoomOut = 40;          //Zoom

    public void Awake()
    {
        //Set up references.
        mainCamera = GameObject.Find("Main Camera").transform;
    }

    //Moves the camera.
    public void CameraMove()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * cameraMoveSpeed, 0, Input.GetAxis("Vertical") * cameraMoveSpeed));
    }
}
