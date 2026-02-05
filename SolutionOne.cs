using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    // ---- VARIABLES ----
    // dictionary with character race and hit die, <string, string>
    private Dictionary<string, int> raceHitDie = new Dictionary<string, int>()
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
        {"Warlock", 8 },
    };
    public int constitution;
    public string characterRace;
    public string characterName;
    public int characterLevel;
    public string feat;
    public string hpStyle; // "average" or "roll"

    // using array for con modifiers, where index is the constitution score
    private int[] constMods = { -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };

    // for average or rolled use either if-else or switch expression

    // ---- METHODS ----
    // hp calculator, method where it all happens. Returns total HP as int
    int CalculateHP()
    {
        int HP = 0;
        // first see if user wants HP averaged or rolled
        if (hpStyle == "averaged")
        {

        }
        else if (hpStyle == "rolled")
        {

        }
        else
        {
            Debug.Log("Error: HP style not valid.");
        }
        return HP;
    }

    // calculate the expected value of die roll
    float averageVal(int hitDie)
    {
        return (hitDie + 1) / 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
