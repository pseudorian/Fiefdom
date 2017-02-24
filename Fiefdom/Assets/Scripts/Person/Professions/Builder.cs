using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;
using Structures;

public class Builder : MonoBehaviour
{
    //References

    //Pre-initialized data
    public static Dictionary<BuildPhase, bool> allowedTasks = new Dictionary<BuildPhase, bool>
    {
        {BuildPhase.Design, false}, {BuildPhase.Carpentry, false}, {BuildPhase.Masonry, false},
        {BuildPhase.Thatching, false}, {BuildPhase.General, false}
    };
    



    void OnEnable()
    {
        
    }

    void OnDisable()
    {

    }
	
}
