using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solution2 : MonoBehaviour
{
    public string characterName;
    public int characterLevel;
    public string characterClass;
    public int conScore;
    public bool hillDwarf;
    public bool toughFeat;
    public bool averagedOrNot;
    private int maxHP;
    // Start is called before the first frame update
    void Start()
    {
        TotalHitPoints();
        Debug.Log(characterName + " is level " + characterLevel + ".  Their current HP is: " + maxHP);
    }
    public void TotalHitPoints()
    {
        maxHP = 0;

        int dieRolls = characterLevel;
        int dieNumber = CharacterClassAssist.ClassDie(characterClass);
        int modifier = CharacterClassAssist.ConstitutionModifier(conScore);

        if (!averagedOrNot)
        {
            int finalValue = CharacterClassAssist.CalculatedValue(dieRolls, dieNumber, modifier);
            maxHP = finalValue; 
        }

        if (hillDwarf)
        {
            maxHP += characterLevel;
        }

        if (toughFeat)
        {
            maxHP += (characterLevel * 2);
        }

        if(averagedOrNot)
        {
            maxHP += CharacterClassAssist.RollTheDies(dieRolls, dieNumber, modifier);
        }
    }
}

public class CharacterClassAssist
{
    public static int ClassDie(string characterClass)
    {
        Dictionary<string, int> classDie = new Dictionary<string, int>
        {
            {"Artificer", 8 },
            {"Barbarian", 12 },
            {"Bard", 8 },
            {"Cleric", 8 },
            {"Druid", 8 },
            {"Fighter", 10 },
            {"Monk", 8 },
            {"Ranger", 10 },
            {"Rogue", 8 },
            {"Paladin", 10 },
            {"Sorcerer", 6 },
            {"Wizard", 6 },
            {"Warlock", 8 }
        };

        if (!classDie.ContainsKey(characterClass))
            return 0;

        return classDie[characterClass];
    }

    public static int ConstitutionModifier(int conScore)
    {
        int modifier = 0;

        switch (conScore)
        {
            case 1:
                modifier = -5;
                break;

            case 2:
            case 3:
                modifier = -4;
                break;
            
            case 4:
            case 5:
                modifier = -3;
                break;

            case 6:
            case 7:
                modifier = -2;
                break;

            case 8:
            case 9:
                modifier = -1;
                break;

            case 10:
            case 11:
                modifier = 0;
                break;

            case 12:
            case 13:
                modifier = 1;
                break;

            case 14:
            case 15:
                modifier = 2;
                break;

            case 16:
            case 17:
                modifier = 3;
                break;

            case 18:
            case 19:
                modifier = 4;
                break;

            case 20:
            case 21:
                modifier = 5;
                break;

            case 22:
            case 23:
                modifier = 6;
                break;

            case 24:
            case 25:
                modifier = 7;
                break;

            case 26:
            case 27:
                modifier = 8;
                break;
            
            case 28:
            case 29:
                modifier = 9;
                break;

            case 30:
                modifier = 10;
                break;

            default:
                modifier = 11;
                break;
        }
        return modifier;
    }

    public static int CalculatedValue(int dieRolls, int dieNumber, int conModifier)
    {
        float average = 0;
        average = ((dieRolls + 1) / 2f) * dieNumber + (conModifier * dieNumber);
        return (int) average; 
    }

    public static int RollTheDies(int dieRolls, int dieNumber, int conModifier)
    {
        int sumOfDie = 0;
        for(int i = 0; i < dieRolls; i++)
            sumOfDie += Random.Range(1, dieNumber) + conModifier;
        return sumOfDie;
    }

}

