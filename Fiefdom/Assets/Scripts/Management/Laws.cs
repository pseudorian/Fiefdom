using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;
using Structures;


/// <summary>
/// This script contains resources pertaining to the current and allowed laws, techs, professions, and other game elements that may
/// determine how a peasant will act in a situation (such as finding work).
/// 
/// If a player creates a new law (implicitly or explicitly), that change is reflected in this script.
/// </summary>
public class Laws : MonoBehaviour
{
    private static ProjectType[] projectTypePriorities = new ProjectType[]
    {
        ProjectType.Build, ProjectType.Farm
    };

    public int GetProjectTypePriority(ProjectType p)
    {
        int priority = -1;
        for(int i = 0; i < projectTypePriorities.Length; i++)
        {
            if(projectTypePriorities[i] == p)
            {
                priority = i;
                break;
            }
        }
        if(priority < 0)
            throw new System.Exception("No project of type " + System.Enum.GetName(typeof(Profession), p) + " was found in a search for its job priority.");
        else
            return priority;
    }

    public void SetProjectTypePriority(ProjectType type, int newPriority)
    {
        int currentPriority = GetProjectTypePriority(type);

        if(newPriority == currentPriority)
            return;
        else if(newPriority < 0 || newPriority > projectTypePriorities.Length - 1)
            throw new System.Exception("Attempted to change a project type to a priority level that is out of bounds.");
        else
        {
            ProjectType newType = type;
            if(newPriority > currentPriority)
            {
                for(int i = newPriority; i >= currentPriority; i--)
                {
                    ProjectType previousType = projectTypePriorities[i];
                    projectTypePriorities[i] = newType;
                    newType = previousType;
                }
            }
            else //if(newPriority < currentPriority)
            {
                for(int i = newPriority; i <= currentPriority; i++)
                {
                    ProjectType previousType = projectTypePriorities[i];
                    projectTypePriorities[i] = newType;
                    newType = previousType;
                }
            }
        }
    }

    public void IncreaseProjectTypePriority(ProjectType type)
    {
        int currentPriority = GetProjectTypePriority(type);

        if(currentPriority == 0)
            return;
        else
        {
            ProjectType previousType = projectTypePriorities[currentPriority - 1];
            projectTypePriorities[currentPriority - 1] = type;
            projectTypePriorities[currentPriority] = previousType;
        }
    }

    public void DecreaseProjectTypePriority(ProjectType type)
    {
        int currentPriority = GetProjectTypePriority(type);

        if(currentPriority == projectTypePriorities.Length - 1)
            return;
        else
        {
            ProjectType previousType = projectTypePriorities[currentPriority + 1];
            projectTypePriorities[currentPriority + 1] = type;
            projectTypePriorities[currentPriority] = previousType;
        }
    }
}
