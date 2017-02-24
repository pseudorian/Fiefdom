using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structures;
using Resources;

public class ContructionManager : MonoBehaviour
{
    //References
    private CursorController curs;

    //Variables
    private GameObject selectedBuilding;


	void Start ()
    {
		curs = GameObject.Find("PlayerController").GetComponent<CursorController>();
	}


    /// <summary>Called when the player has clicked on the (valid) area on which they wish to build the
    /// selected building. The building is instantiated in its frame state and is supplied with the
    /// proper project file to begin construction.</summary>
    private void Designate()
    {
        GameObject newDesignation = Instantiate(selectedBuilding, curs.GetCursorPosition(1 << CursorController.TERRAIN_LAYER),
            Quaternion.identity) as GameObject;

        Building newBuilding = newDesignation.GetComponent<Building>();
        newBuilding.InitializeConstruction();
    }
}
