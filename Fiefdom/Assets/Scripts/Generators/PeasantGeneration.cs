using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;


/// <summary>
/// This script is used in generating peasants from a given circumstance. It covers initial generation, peasant birth, and migrant generation.
/// </summary>
public class PeasantGeneration : MonoBehaviour
{
    public List<Peasant> GenerateInitialFamily()
    {
        //Max number of family members = 10
        int nMembers;
        SortedList<int, int> nMemberList = new SortedList<int, int>()
        {
            {1, 9}, {2, 11}, {Random.Range(3, 6), 6}, {6, 2 }, {Random.Range(7, 11), 1}
        };
        nMembers = GF.WeightedRandom(nMemberList);

        //Determine if there will be one or two parents.
        int nParents;
        int j = Random.Range(0, 30);
        if(j < 25)
            nParents = 2;
        else
            nParents = 1;

        return GenerateMembers(nMembers, nParents);
    }

    //Generates the individual members of the family.
    List<Peasant> GenerateMembers(int nMembers, int nParents)
    {
        string familySurname = "";
        List<Peasant> familyMembers = new List<Peasant>();
        for(int i = 0; i < nMembers; i++)
        {
            Peasant p;
            if(nParents == 2)
            {
                switch(i)
                {
                    case 0:
                        p = GenerateAdult(Gender.Male);
                        familySurname = p.name.sur;
                        break;

                    case 1:
                        p = GenerateAdult(Gender.Female);
                        break;

                    default:
                        p = GenerateChild();
                        break;
                }
            }
            else
            {
                switch(i)
                {
                    case 0:
                        p = GenerateAdult();
                        familySurname = p.name.sur;
                        break;

                    default:
                        p = GenerateChild();
                        break;
                }
            }
            familyMembers.Add(p);
        }
        List<Peasant> generatedFamily = GenerateFamilyRelationships(familyMembers, familySurname);
        return generatedFamily;
    }

    //Generates the relationships between each family member based on age and gender.
    List<Peasant> GenerateFamilyRelationships(List<Peasant> familyMembers, string familySurName)
    {
        foreach(Peasant p in familyMembers)
        {
            //Set their surname to the family leader's surname.
            p.name.ChangeSurname(familySurName);
            if(familyMembers.Count > 1)
            {
                foreach(Peasant fMember in familyMembers)
                {
                    if(p != fMember)
                    {
                        //if p is an adult...
                        if(p.age >= 13)
                        {
                            //if fMember is an adult, then set fMember as spouse of p.
                            if(fMember.age >= 13)
                                p.family.AddSpouse(fMember);
                            //else if fMember is a child, then set fMember as child of p.
                            else
                                p.family.AddChild(fMember);
                        }
                        //else if p is a child...
                        else
                        {
                            //if fMember is an adult, then set fMember as parent of p.
                            if(fMember.age >= 13)
                            {
                                if(fMember.gender == Gender.Male)
                                    p.family.AddFather(fMember);
                                else
                                    p.family.AddMother(fMember);
                            }
                            //else if fMember is a child, then set fMember as sibling of p.
                            else
                            {
                                p.family.siblings.Add(fMember);
                            }
                        }
                    }
                }
            }
        }
        return familyMembers;
    }

    Peasant GenerateAdult()
    {
        Gender gender;
        int i = Random.Range(0, 10);
        if(i < 7)
            gender = Gender.Male;
        else
            gender = Gender.Female;

        float age;
        int j = Random.Range(0, 10);
        if(j < 7)
            age = Random.Range(18f, 30f);
        else if(j < 9)
            age = Random.Range(13f, 18f);
        else
            age = Random.Range(30f, 50f);

        return new Peasant(gender, age);
    }

    Peasant GenerateAdult(Gender gender)
    {
        float age;
        int j = Random.Range(0, 10);
        if(j < 7)
            age = Random.Range(18f, 30f);
        else if(j < 9)
            age = Random.Range(13f, 18f);
        else
            age = Random.Range(30f, 50f);

        return new Peasant(gender, age);
    }

    Peasant GenerateChild()
    {
        Gender gender;
        int i = Random.Range(0, 100);
        if(i < 53)
            gender = Gender.Male;
        else
            gender = Gender.Female;

        float age;
        int j = Random.Range(0, 10);
        if(j < 4)
            age = Random.Range(4f, 9f);
        else if(j < 6)
            age = Random.Range(0f, 4f);
        else
            age = Random.Range(9f, 13f);

        return new Peasant(gender, age);
    }
}
