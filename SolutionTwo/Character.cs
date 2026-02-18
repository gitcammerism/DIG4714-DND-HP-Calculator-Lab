using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // variables
    protected string charName;
    protected int constitution;
    protected string race;
    protected string feat;
    protected string hpStyle;
    protected int level;
    protected string charClass;
    protected int hitDie;
    protected int constModifier;

    // dictionary with character race and hit die, <string, string>
    protected Dictionary<string, int> raceHitDie = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
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

    // using array for con modifiers, where index is the constitution score
    protected int[] constMods = { -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };

    public virtual void DisplayInfo()
    {
        Debug.Log("Character Name: " + charName);
    }



}
