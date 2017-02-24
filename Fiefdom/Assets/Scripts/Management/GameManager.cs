using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;
using Structures;
using Resources;

public class GameManager : MonoBehaviour
{
    //References
    private Laws laws;

    //Collections
    public List<Project> pConstruction { get; private set; }

    //Project priority lists
    public List<Project> priorityHigh { get; private set; }
    public List<Project> priorityNormal { get; private set; }
    public List<Project> priorityLow { get; private set; }


    void Awake()
    {
        //Set up references.
        laws = GetComponent<Laws>();

        //Initializations.
        Res.Initialize();
        InitializeCollections();
    }


    private void InitializeCollections()
    {
        pConstruction = new List<Project>();
    }

    public void AddProjectConstruction(Project p)
    {
        pConstruction.Add(p);
        priorityNormal.Add(p);
    }

    public void RemoveProjectConstruction(Project p)
    {
        pConstruction.Remove(p);

    }

    public void ChangeProjectPriority(Project project, Priority newPriority)
    {
        if(project.priority == newPriority)
            return;

        switch(project.priority)
        {
            case Priority.High:
                priorityHigh.Remove(project);
                break;
            case Priority.Normal:
                priorityNormal.Remove(project);
                break;
            case Priority.Low:
                priorityLow.Remove(project);
                break;
        }

        switch(newPriority)
        {
            case Priority.High:
                priorityHigh.Add(project);
                break;
            case Priority.Normal:
                priorityNormal.Add(project);
                break;
            case Priority.Low:
                priorityLow.Add(project);
                break;
        }
    }
}
