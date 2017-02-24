using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structures;
using Resources;

public abstract class Building : MonoBehaviour
{
    protected Project projectFile;
    protected BuildingCondition condition;

    /// <summary>
    /// The implementation of this method provides this base class with its initial project file (which
    /// is the construction of this building).
    /// </summary>
    public abstract void InitializeConstruction();

    /// <summary>
    /// Cancels the construction of this building prematurely.
    /// </summary>
    public abstract void CancelConstruction();

    /// <summary>
    /// The implementation of this method provides a means of completing the construction of this building
    /// so that it may begin to function. This marks the end of the construction phase, NOT the beginning of
    /// the functioning phase.
    /// </summary>
    public abstract void CompleteConstruction();

    /// <summary>
    /// The implementation of this method provides this base class with the information it needs
    /// to function after construction is complete (i.e. providing the on-going project file) as well as
    /// initializing members in its associated extension class.
    /// </summary>
    public abstract void InitializeFunction();

    /// <summary>
    /// Marks this construction for demolition. This does not destroy the building immediately.
    /// </summary>
    public abstract void MarkForDemolotion();

    /// <summary>
    /// Destroys this building immediately.
    /// </summary>
    public abstract void DestroyBuilding();
}
