using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;

public class Builder : MonoBehaviour
{
    //References

    //Pre-initialized data
    public static Dictionary<BuildPhase, bool> allowedJobs = new Dictionary<BuildPhase, bool>
    {
        {BuildPhase.design, false}, {BuildPhase.carpentry, false}, {BuildPhase.masonry, false},
        {BuildPhase.thatching, false}, {BuildPhase.general, false}
    };
    



    public void OnEnable()
    {

    }

    public void OnDisable()
    {

    }
	
}
