using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    // ---- VARIABLES ----
    // dictionary with character race and hit die, <string, string>
    private Dictionary<string, int> raceHitDie = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
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
    public string characterClass;
    public string characterName;
    public int characterLevel;
    public string feat; // "tough" or "stout"
    public string hpStyle; // "average" or "roll"

    // using array for con modifiers, where index is the constitution score
    private int[] constMods = { -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };

    // for average or rolled use either if-else or switch expression

    // ---- METHODS ----
    // hp calculator, method where it all happens. Returns total HP as int
    int CalculateHP()
    {
        int hp = 0;
        // first see if user wants HP averaged or rolled
        if (hpStyle == "averaged")
        {
            if (raceHitDie.ContainsKey(characterClass))
            {
                // call averageVal method to get average value of hit die and multiply by char lvl, and then add const mod per level
                Debug.Log(averageVal(raceHitDie[characterClass]));
                hp = (characterLevel * averageVal(raceHitDie[characterClass])) + (characterLevel * constMods[constitution - 1]);
                Debug.Log(hp);
            }
            else
            {
                Debug.Log("Please select a valid character class.");
            }
        }
        else if (hpStyle == "rolled")
        {
            if (raceHitDie.ContainsKey(characterClass))
            {
                // roll die with Random.Range per character level, then add const modifier per level
                for (int i = 0; i < characterLevel; i++)
                {
                    hp += UnityEngine.Random.Range(1, raceHitDie[characterClass] + 1) + constMods[constitution - 1];
                    Debug.Log(hp);
                }
            }
            else
            {
                Debug.Log("Please select a valid character class.");
            }
        }
        else
        {
            Debug.Log("Error: HP style not valid.");
        }

        // race and tough/stout HP add ons
        hp += raceHp() + featHp();
        Debug.Log(hp);


        return hp;
    }

    // calculate the expected value of die roll. Rounds up to the nearest int
    int averageVal(double hitDie)
    {
        return (int)Math.Ceiling((hitDie + 1) / 2);
    }

    int raceHp()
    {
        // add HP based on Dwarf, Orc, or Goliath
        int additionalHp = 0;
        switch (characterRace)
        {
            case "Dwarf":
                additionalHp += 2 * characterLevel;
                break;
            case "Orc":
            case "Goliath":
                additionalHp += 1 * characterLevel;
                break;
            default:
                break;
        }
        return additionalHp;
    }

    int featHp()
    {
        // add HP based on Tough or Stout feat
        int additionalHp = 0;
        switch (feat)
        {
            case "Tough":
                additionalHp += 2 * characterLevel;
                break;
            case "Stout":
                additionalHp += 1 * characterLevel;
                break;
            default:
                feat = "no";
                break;
        }
        return additionalHp;
    }

    // Start is called before the first frame update
    void Start()
    {
        int healthPoints = CalculateHP();
        Debug.Log("My character " + characterName + " is a level " + characterLevel + " " + characterClass + " with a CON score of " + constitution + " and is of " + characterRace + " race and has " + feat + " feat. I want the HP " + hpStyle + ".");
        Debug.Log("My character has " + healthPoints + " HP.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
