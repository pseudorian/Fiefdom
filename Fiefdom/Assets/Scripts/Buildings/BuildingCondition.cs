using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCondition
{
    //Material levels
    public int woodCurrent;
    public int woodMax;
    public int stoneCurrent;
    public int stoneMax;
    public int strawCurrent;
    public int strawMax;
    public int brickCurrent;
    public int brickMax;
    public int ironCurrent;
    public int ironMax;

    
    public BuildingCondition(int wood, int stone, int straw, int brick, int iron)
    {
        woodMax = wood;
        stoneMax = stone;
        strawMax = straw;
        brickMax = brick;
        ironMax = iron;
        woodCurrent = 0;
        stoneCurrent = 0;
        strawCurrent = 0;
        brickCurrent = 0;
        ironCurrent = 0;
    }
}
