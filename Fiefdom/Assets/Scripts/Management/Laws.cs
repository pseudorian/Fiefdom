using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using People;


/// <summary>
/// This script contains resources pertaining to the current and allowed laws, techs, professions, and other game elements that may
/// determine how a peasant will act in a situation (such as finding work).
/// 
/// If a player creates a new law (implicitly or explicitly), that change is reflected in this script.
/// </summary>
public class Laws : MonoBehaviour
{
    private static Profession[] jobPriorities = new Profession[]
    {
        Profession.architect, Profession.brewer, Profession.builder, Profession.carpenter, Profession.ceramist, Profession.clayExtractor,
        Profession.farmer, Profession.mason, Profession.miner, Profession.quarrier, Profession.thatcher, Profession.timberman
    };

    public void ChangeJobPriority(Profession profession, int priority)
    {
        int currentPriority = GetJobPriority(profession);
        
    }

    public int GetJobPriority(Profession profession)
    {
        int priority = -1;
        for(int i = 0; i < jobPriorities.Length; i++)
        {
            if(jobPriorities[i] == profession)
            {
                priority = i;
                break;
            }
        }
        if(priority < 0)
            throw new System.Exception("No profession of type " + Enum.GetName(typeof(Profession), profession) + " was found in a search for its job priority.");
        else
            return priority; 
    }
}
