using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHealth
{
    //Health of body parts on a scale from 0-100.
    public int head;
    public int lArm;
    public int rArm;
    public int lLeg;
    public int rLeg;
    public int torso;
    public int internalBody;

    public PersonHealth()
    {
        head = 100;
        lArm = 100;
        rArm = 100;
        lLeg = 100;
        rLeg = 100;
        torso = 100;
        internalBody = 100;
    }
}
