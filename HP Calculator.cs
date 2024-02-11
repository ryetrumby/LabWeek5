using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCalculator : MonoBehaviour
{
    private int maxHP;
    private int diceToUse;
    private float avgHitDie;
    [SerializeField] private string charClass;
    [SerializeField] private int charLevel;
    [SerializeField] private int constScore;
    [SerializeField] private bool hillDwarf;
    [SerializeField] private bool tough;
    [SerializeField] private bool averaged;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        checkForCharClass();
    }
    void checkForCharClass()
    {
        if (dieClass.ContainsKey(charClass))
            {
                int value = dieClass[charClass];
                diceToUse = value;
                Debug.Log("Uses this Dice: " + diceToUse);
            }
            else
            {
                Debug.Log("Class does not exist in 5e");
            }
    }
    //The comment below should be the final output
    //Debug.Log("Your HP value is : " + maxHP)
}
