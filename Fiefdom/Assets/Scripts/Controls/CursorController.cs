using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour
{

    //References
    private PointerInputModule pointerInput;

    //Stores the lock state of the cursor.
    private bool _isLocked = false;
    public bool isLocked
    {
        get
        {
            return this._isLocked;
        }
    }

    //If set to true, this script will, on Update(), calculate the world space coords on the cursor (stored in pointerPos).
    public bool needCursorPos = false;
    private Vector3 _cursorPos = new Vector3();
    public Vector3 cursorPos
    {
        get
        {
            _cursorPos = GetCursorPosition();
            return _cursorPos;
        }
    }

    //Layer Masks
    public const int TERRAIN_LAYER = 10;



    void Awake()
    {
        pointerInput = GameObject.Find("EventSystem").GetComponent<PointerInputModule>();
    }

    void Update()
    {
        //If the pointer position is requested by another script, find pointer position in world space.
        if(needCursorPos)
        {
            if(IsCursorOverUI() == false)
            {
                _cursorPos = GetCursorPosition();
            }
        }
    }


    //Returns true if cursor is over a UI object, false if not.
    public bool IsCursorOverUI()
    {
        //If the cursor is not over a UI object...
        if(pointerInput.IsPointerOverGameObject(-1))
            return true;
        else
            return false;
    }

    //Returns the cursor's current location in world space.
    public Vector3 GetCursorPosition()
    {
        return GetCursorPosition(~0);
    }

    public Vector3 GetCursorPosition(int layerMask)
    {
        RaycastHit cursorHit = GetCursorRaycastHit(layerMask);
        return cursorHit.point;
    }

    public RaycastHit GetCursorRaycastHit()
    {
        return GetCursorRaycastHit(~0);
    }

    public RaycastHit GetCursorRaycastHit(int layerMask)
    {
        Ray cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit cursorHit;

        if(Physics.Raycast(Camera.main.transform.position, cursorRay.direction, out cursorHit, Mathf.Infinity, layerMask))
        {
            return cursorHit;
        }
        else
            return new RaycastHit();
    }


    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        ShowCursor();
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HideCursor();
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }
}

