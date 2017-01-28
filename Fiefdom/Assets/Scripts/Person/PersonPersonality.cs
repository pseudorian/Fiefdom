using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;
using System.Xml;

public class PersonPersonality
{
    public int workEthic;
    public int likeability;
    public int attractiveness;
    public int eccentricity;
    public List<PersonalityTrait> traits;


    public PersonPersonality(int workEthic, int likeability, int attractiveness, int eccentricity)
    {
        this.workEthic = workEthic;
        this.likeability = likeability;
        this.attractiveness = attractiveness;
        this.eccentricity = eccentricity;
    }
}
