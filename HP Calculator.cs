using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPCalculator : MonoBehaviour
{
    private int maxHP;
    private int diceToUse;
    private int constProficiency;
    private float avgHitDie;
    private int randHitDie;
    private int hillDwarfBonus;
    private int toughBonus;
    private int constBonus;
    [SerializeField] private string charName;
    [SerializeField] private string charClass;
    [SerializeField] private int charLevel;
    [SerializeField] private int constScore;
    [SerializeField] private bool hillDwarf;
    [SerializeField] private bool tough;
    [SerializeField] private bool averaged;

    // Dictionary for hit dice values
    Dictionary<string, int> dieClass =
        new Dictionary<string, int>()
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

    // Dictionary for consitution proficiency modifiers
    Dictionary<int, int> constModifier =
        new Dictionary<int, int>()
        {
            {1, -5 },
            {2, -4 },
            {3, -4 },
            {4, -3 },
            {5, -3 },
            {6, -2 },
            {7, -2 },
            {8, -1 },
            {9, -1 },
            {10, 0 },
            {11, 0 },
            {12, 1 },
            {13, 1 },
            {14, 2 },
            {15, 2 },
            {16, 3 },
            {17, 3 },
            {18, 4 },
            {19, 4 },
            {20, 5 },
            {21, 5 },
            {22, 6 },
            {23, 6 },
            {24, 7 },
            {25, 7 },
            {26, 8 },
            {27, 8 },
            {28, 9 },
            {29, 9 },
            {30, 10 }
        };   

    // Start is called before the first frame update
    void Start()
    {
        checkForCharClass();
        checkForConstModifier();
        HpCalculator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function for determining hit die of class
    void checkForCharClass()
    {
        if (dieClass.ContainsKey(charClass))
            {
                int value = dieClass[charClass];
                diceToUse = value;
                Debug.Log("Class uses this Dice: " + diceToUse);
            }
            else
            {
                Debug.Log("Class does not exist in 5e");
            }
    }

    // Function for calculating the constitution score proficiency
    void checkForConstModifier()
    {
        if (constModifier.ContainsKey(constScore))
        {
            int value = constModifier[constScore];
            constProficiency = value;
            Debug.Log("Constitution proficiency is " + constProficiency);
        }
        else
        {
            Debug.Log("Invalid constitution score entered");
        }
    }


    // Function for calculating the HP of the character
    void HpCalculator()
    {
        avgHitDie = (diceToUse + 1) / 2;
        constBonus = charLevel * constProficiency;

        int numOfDie = charLevel;
        var hitDiceRolls = new int[numOfDie];

        for (int i = 0; i < numOfDie; i++)
        {
            hitDiceRolls[i] = Random.Range(1, diceToUse);
        }

        foreach (var value in hitDiceRolls)
        {
            randHitDie += value;
        }

        if (hillDwarf == true)
        {
            hillDwarfBonus = charLevel;
        }
        else
        {
            hillDwarfBonus = 0;
        }

        if (tough == true)
        {
            toughBonus = 2 * charLevel;
        }
        else
        {
            toughBonus = 0;
        }

        if (averaged == true)
        {
            maxHP = ((int)avgHitDie * charLevel) + hillDwarfBonus + constBonus + toughBonus;
        }
        else
        {
            maxHP = randHitDie + hillDwarfBonus + constBonus + toughBonus;
        }

        Debug.Log(charName + " the " + charClass + " has a total HP of " + maxHP);
    }

    //The comment below should be the final output
    //Debug.Log("Your HP value is : " + maxHP)
}
