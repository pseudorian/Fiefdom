using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structures;
using Resources;
using People;

public class BStorageYard : Building
{
    //References
    private GameManager gm;

    //Construction requirements
    private const int REQ_WOOD = 10;
    private const int REQ_STONE = 5;

    //Implementations
    public override void InitializeConstruction()
    {
        //Set up condition (for initial use in construction)
        condition = new BuildingCondition(wood:REQ_WOOD, stone:REQ_STONE, straw:0, brick:0, iron:0);

        //Develop construction project file.
        projectFile = new Project(transform, ProjectType.Build);
        //Develop and add gather tasks.
        GatherTask gatherWood = new GatherTask(Res.Wood(REQ_WOOD));
        GatherTask gatherStone = new GatherTask(Res.Stone(REQ_STONE));
        projectFile.tasks.Add(gatherWood);
        projectFile.tasks.Add(gatherStone);
        //Develop and add build tasks.
        BuildTask carpentry = new BuildTask(BuildPhase.Carpentry);
        BuildTask masonry = new BuildTask(BuildPhase.Masonry);
        projectFile.tasks.Add(carpentry);
        projectFile.tasks.Add(masonry);

        //Add project file to list of available construction projects.
        gm.AddProjectConstruction(projectFile);
    }

    public override void CancelConstruction()
    {
        //Remove construction project from GameManager list.
        gm.RemoveProjectConstruction(projectFile);
    }

    public override void CompleteConstruction()
    {
        //Remove construction project from GameManager list and clear
        //the local projectFile for future use in functional phase.
        gm.RemoveProjectConstruction(projectFile);
        projectFile.Clear();
    }

    public override void InitializeFunction()
    {
        
    }

    public override void MarkForDemolotion()
    {
        
    }

    public override void DestroyBuilding()
    {
        Destroy(gameObject);
    }


    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
