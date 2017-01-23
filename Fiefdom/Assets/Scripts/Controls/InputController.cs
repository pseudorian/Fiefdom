using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script records all input (other than UI clicks which are filtered) and routes them to the appropriate action
/// depending on the current circumstances.
/// </summary>
public class InputController : MonoBehaviour
{
    //References
    private UIManager uiManager;
    private GameManager gameManager;
    private CursorController cursControl;
    private CameraController camControl;
    

    public void Awake()
    {
        //Set up references.
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cursControl = GameObject.Find("Player Controller").GetComponent<CursorController>();
        camControl = GameObject.Find("Player Controller").GetComponent<CameraController>();
    }

    public void Update()
    {
        if(Input.GetButton("Left Click"))
        {
            //Ensure the cursor is not over a UI component.
            if(!cursControl.IsCursorOverUI())
            {

            }
        }

        if(Input.GetButton("Right Click"))
        {
            //Ensure the cursor is not over a UI component.
            if(!cursControl.IsCursorOverUI())
            {

            }
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            //Move camera
            camControl.CameraMove();
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            //Move camera
            camControl.CameraMove();
        }
    }
}
